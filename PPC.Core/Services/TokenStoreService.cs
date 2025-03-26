using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Core.Common;
using WebApi.Core.Interface;
using WebApi.Core.Models;
using WebApi.Core.Repository;
using System;
using System.Threading.Tasks;

namespace WebApi.Core.Services
{
    public class TokenStoreService : BaseService,ITokenStoreService
    {
        #region Properties
        private readonly ISecurityService _securityService;
        private readonly IOptionsSnapshot<JwtConfigOptions> _configuration;
        private readonly ITokenFactoryService _tokenFactoryService;
        #endregion Properties

        #region Ctor
        public TokenStoreService(
    ISecurityService securityService,
    IOptionsSnapshot<JwtConfigOptions> configuration,
    ITokenFactoryService tokenFactoryService, IUnitOfWork unitOfWork, RepositoryFactory repositoryFactory)
        {
            _unitOfWork = unitOfWork;
            _repositoryFactory = repositoryFactory;


            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));


            _configuration = configuration;
            _configuration.CheckArgumentIsNull(nameof(configuration));

            _tokenFactoryService = tokenFactoryService;
            _tokenFactoryService.CheckArgumentIsNull(nameof(tokenFactoryService));
        }
        #endregion

        #region Public Method

        public async Task AddUserTokenAsync(SysUserToken userToken)
        {
            if (!_configuration.Value.AllowMultipleLoginsFromTheSameUser)
            {
                await InvalidateUserTokensAsync(userToken.UserId);
            }
            await DeleteTokensWithSameRefreshTokenSourceAsync(userToken.RefreshTokenIdHashSource);
            _repositoryFactory.SysUserTokens.Add(userToken);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddUserTokenAsync(SysUserAccount user, string refreshTokenSerial, string accessToken, string refreshTokenSourceSerial)
        {
            var now = DateTimeOffset.UtcNow;
            var token = new SysUserToken
            {
                UserId = user.ID,
                // Refresh token handles should be treated as secrets and should be stored hashed
                RefreshTokenIdHash = _securityService.GetSha256Hash(refreshTokenSerial),
                RefreshTokenIdHashSource = string.IsNullOrWhiteSpace(refreshTokenSourceSerial) ?
                                           null : _securityService.GetSha256Hash(refreshTokenSourceSerial),
                AccessTokenHash = _securityService.GetSha256Hash(accessToken),
                RefreshTokenExpiresDateTime = now.AddMinutes(_configuration.Value.RTExpires),
                AccessTokenExpiresDateTime = now.AddMinutes(_configuration.Value.ATExpires)
            };
            await AddUserTokenAsync(token);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteExpiredTokensAsync()
        {
            var now = DateTimeOffset.UtcNow;
            await _repositoryFactory.SysUserTokens.Where(x => x.RefreshTokenExpiresDateTime < now)
                        .ForEachAsync(userToken => _repositoryFactory.SysUserTokens.Delete(userToken));
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTokenAsync(string refreshTokenValue)
        {
            var token = await FindTokenAsync(refreshTokenValue);
            if (token != null)
            {
                _repositoryFactory.SysUserTokens.Delete(token);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenIdHashSource))
            {
                return;
            }

            await _repositoryFactory.SysUserTokens.Where(t => t.RefreshTokenIdHashSource == refreshTokenIdHashSource ||
                                     t.RefreshTokenIdHash == refreshTokenIdHashSource &&
                                      t.RefreshTokenIdHashSource == null)
                .ForEachAsync(userToken => _repositoryFactory.SysUserTokens.Delete(userToken));
            await _unitOfWork.CommitAsync();
        }

        public async Task<SysUserToken> FindTokenAsync(string refreshTokenValue)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenValue))
            {
                return await Task.FromResult<SysUserToken>(null);
            }

            var refreshTokenSerial = _tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue);
            if (string.IsNullOrWhiteSpace(refreshTokenSerial))
            {
                return await Task.FromResult<SysUserToken>(null);
            }

            var refreshTokenIdHash = _securityService.GetSha256Hash(refreshTokenSerial);
            return await _repositoryFactory.SysUserTokens.Table.Include(x => x.User).FirstOrDefaultAsync(x => x.RefreshTokenIdHash == refreshTokenIdHash);
        }

        public async Task InvalidateUserTokensAsync(int userId)
        {
            await _repositoryFactory.SysUserTokens.Where(x => x.UserId == userId)
            .ForEachAsync(userToken => _repositoryFactory.SysUserTokens.Delete(userToken));
        }

        public async Task<bool> IsValidTokenAsync(string accessToken, int userId)
        {
            var accessTokenHash = _securityService.GetSha256Hash(accessToken);
            var userToken = await _repositoryFactory.SysUserTokens.FirstOrDefaultAsync(
                x => x.AccessTokenHash == accessTokenHash && x.UserId == userId);
            return userToken?.AccessTokenExpiresDateTime >= DateTimeOffset.UtcNow;
        }

        public async Task RevokeUserBearerTokensAsync(string userIdValue, string refreshTokenValue)
        {
            if (!string.IsNullOrWhiteSpace(userIdValue) && int.TryParse(userIdValue, out int userId))
            {
                if (_configuration.Value.AllowSignoutAllUserActiveClients)
                {
                    await InvalidateUserTokensAsync(userId);
                }
            }

            if (!string.IsNullOrWhiteSpace(refreshTokenValue))
            {
                var refreshTokenSerial = _tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue);
                if (!string.IsNullOrWhiteSpace(refreshTokenSerial))
                {
                    var refreshTokenIdHashSource = _securityService.GetSha256Hash(refreshTokenSerial);
                    await DeleteTokensWithSameRefreshTokenSourceAsync(refreshTokenIdHashSource);
                }
            }

            await DeleteExpiredTokensAsync();
            await _unitOfWork.CommitAsync();
        } 
        #endregion
    }
    
}
