using AtlasCellData;
using WebApi.Core.Models;
using WebApi.Core.Models.Jwt;
using WebApi.Response.DTOs;
using System.Collections.Generic;
using System.Linq;
using static System.Collections.Specialized.BitVector32;
using WebApi.Base.Extensions;
using System;
using AtlasCellData.ADO;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using AC_PPC.Response.DTOs;
using WebApi.Base.Utility;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebApi.Core.Extensions
{

    public partial class ExtAutoMapper
    {
        public static TDestination JsonMap<TSource, TDestination>(TSource source)
        {
            var src = JsonConvert.SerializeObject(source, Formatting.None
                        , new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }
                        );
            var dest= JsonConvert.DeserializeObject<TDestination>(src
                        ,new JsonSerializerSettings()
                        //{
                        //    NullValueHandling = NullValueHandling.Ignore
                        //}
                        );

            return dest;
        }

    }
    public partial class ExtAutoMapper
    {
        private static Mapper _initializeAutomapper = null;
        public static Mapper Mapper { get; } = InitializeAutomapper();
        public static Mapper InitializeAutomapper()
        {

            //singletone
            if (_initializeAutomapper != null)
                return _initializeAutomapper;

            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {



                #region ModelDTO to Model

                //Configuring 
                cfg.CreateMap<Temp, TempDTO>();
                //cfg.CreateMap<List<Temp>, List<TempDTO>>();


                cfg.CreateMap<Users, UsersDTO>().MaxDepth(15);
                cfg.CreateMap<Units, UnitsDTO>().MaxDepth(15);
                cfg.CreateMap<Provinces, ProvincesDTO>().MaxDepth(15);
                cfg.CreateMap<Domain, DomainDTO>().MaxDepth(15);
                cfg.CreateMap<Countries, CountriesDTO>().MaxDepth(15);
                cfg.CreateMap<Settings, SettingsDTO>().MaxDepth(15);
                cfg.CreateMap<SettingUpdates, SettingUpdatesDTO>().MaxDepth(15);
                cfg.CreateMap<SettingGenerals, SettingGeneralsDTO>().MaxDepth(15);
                cfg.CreateMap<MenuAccessStates, MenuAccessStatesDTO>().MaxDepth(15);
                cfg.CreateMap<DenyAccesses, DenyAccessesDTO>().MaxDepth(15);
                cfg.CreateMap<LoginLogs, LoginLogsDTO>().MaxDepth(15);
                cfg.CreateMap<Logs, LogsDTO>().MaxDepth(15);
                cfg.CreateMap<AutoCompleteField, AutoCompleteFieldDTO>().MaxDepth(15);

                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);
                //cfg.CreateMap<, DTO>().MaxDepth(15);

                #endregion ModelDTO to Model

                

            });

            //Create an Instance of Mapper and return that Instance

            _initializeAutomapper = new Mapper(config);


            return _initializeAutomapper;
        }

    }

    public partial class ExtAutoMapper
    {

        //public static void TempMapper<TSource, TDestination>(TSource obj)
        //{
        //    //Initializing AutoMapper
        //    var mapper = AutoMapperConfig.InitializeAutomapper();
        //    //Way1: Specify the Destination Type and to The Map Method pass the Source Object
        //    //Now, empDTO1 object will having the same values as emp object
        //    //var empDTO1 = mapper.Map<T>(tt);
        //    var empDTO1 = mapper.Map<TDestination>(obj);
        //    //var empDTO2 = mapper.Map<Temp, TempDTO>(tt);

        //}

        public static void TempMapper<TSource, TDestination>(TSource obj)
        {
            //Initializing AutoMapper
            var mapper = ExtAutoMapper.InitializeAutomapper();



            var empDTO1 = mapper.Map<TDestination>(obj);
            var empDTO2 = mapper.Map<TDestination>(obj);
            //var empDTO2 = mapper.Map<Temp, TempDTO>(tt);

        }

        /// <summary>
        /// پس از مپ کردن رشته جیسون بازمیگرداند
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string MapToJson<TSource, TDestination>(TSource obj)
        {
            try
            {
                var mapped = ExtAutoMapper.Mapper.Map<TSource, TDestination>(obj);

                var jStr = JSON.ToJson(mapped).Result;

                return jStr;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// پس از مپ کردن رشته جیسون بازمیگرداند
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<string> MapToJsonList<TSource, TDestination>(TSource obj)
        {
            try
            {
                var mapped = ExtAutoMapper.Mapper.Map<TSource, TDestination>(obj);

                var jStr = JSON.ToJson(mapped).Result;

                return new List<string>() { jStr };
            }
            catch
            {
                throw;
            }
        }


    }

    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(
            this IQueryable<TEntity> query,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            if (includes == null || includes.Length == 0)
                return query;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }

    public static partial class ModelExtensions
    {
        public static List<T> ToListIfNotEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Count() == 0 ? null : enumerable.ToList();
        }

        public static TokenDto ConvertToDto(this JwtTokensData token)
        {
            return new TokenDto
            {

                Token = "Bearer " + token.AccessToken,
                //   RefreshToken = token.RefreshToken,
            };
        }
        public static List<TokenDto> ConvertToListDto(this JwtTokensData token)
        {
            List<TokenDto> list2 = new List<TokenDto>();
            list2.Add(token.ConvertToDto());
            return list2;

        }

        #region ConvertToDto

        public static SysUserDto ConvertToDto(this SysUserAccount token)
        {
            return new SysUserDto
            {
                Username = token.Username,
                FirstName = token.FirstName,
                LastName = token.LastName,
                IsActive = token.IsActive,
            };
        }
        public static UsersDTO ConvertToDto(this Users user)
        {
            if (user == null)
                return null;

            return new UsersDTO
            {
                //UserID = user.UserID,
                //Username = user.Username,
                //FullName = user.FullName ?? string.Empty,
                //MessageSignature = user.MessageSignature ?? string.Empty,
                //Description = user.Description ?? string.Empty,
                //CanLogin = user.CanLogin,
                //IsActive = user.IsActive,

                UserID = user.UserID,
                FullName = user.FullName,
                Username = user.Username,
                Password = user.Password,
                Last = user.Last,
                StationID = user.StationID,
                AuthenticationType = user.AuthenticationType,
                Description = user.Description,
                DomainID = user.DomainID,
                LoginType = user.LoginType,
                CanLogin = (bool)user.CanLogin,
                IsEntered = user.IsEntered,
                IsActive = user.IsActive,
                IsAdmin = user.IsAdmin,
                IsSysAdmin = user.IsSysAdmin,
                IsManager = user.IsManager,
                IsSupervisor = user.IsSupervisor,
                IsExpert = user.IsExpert,
                IsOperator = user.IsOperator,
                IsSpecialUser = user.IsSpecialUser,
                GetUrgentRequest = user.GetUrgentRequest,
                MessageSignature = user.MessageSignature,
                InsDate = user.InsDate,
                InsTime = user.InsTime,
                InsUserID = user.InsUserID,
                EditDate = user.EditDate,
                EditTime = user.EditTime,
                EditUserID = user.EditUserID,


            };
        }
        public static UnitsDTO ConvertToDto(this Units unit)
        {
            if (unit == null)
                return null;

            return new UnitsDTO
            {
                UnitID = unit.UnitID,
                UnitName = unit.UnitName ?? string.Empty,
                UnitLatinName = unit.UnitLatinName ?? string.Empty,
                Abbreviation = unit.Abbreviation,
            };
        }

        public static DomainDTO ConvertToDto(this Domain domain)
        {
            if (domain == null)
                return null;

            return new DomainDTO
            {
                DomainID = domain.DomainID,
                DomainName = domain.DomainName ?? string.Empty,
                DomainAddress = domain.DomainAddress ?? string.Empty,
                Describe = domain.Describe ?? string.Empty,
                IsActive = domain.IsActive,
            };
        }


        public static ProvincesDTO ConvertToDto(this Provinces provinces)
        {
            if (provinces == null)
                return null;

            return new ProvincesDTO
            {
                ProvinceID = provinces.ProvinceID,
                CountryID = provinces.CountryID,
                Countries = provinces.Countries.ConvertToDto(),
                ProvinceCode = provinces.ProvinceCode ?? string.Empty,
                ProvinceName = provinces.ProvinceName ?? string.Empty,
                ProvinceLatinName = provinces.ProvinceLatinName ?? string.Empty,
                IsActive = provinces.IsActive,
            };
        }

        public static CountriesDTO ConvertToDto(this Countries countries)
        {
            if (countries == null)
                return null;

            return new CountriesDTO
            {
                CountryID = countries.CountryID,
                CountryName = countries.CountryName,
                CountryLatinName = countries.CountryLatinName,
                IsActive = countries.IsActive,

            };
        }
        public static SettingUpdatesDTO ConvertToDto(this SettingUpdates settingUpdates)
        {
            if (settingUpdates == null)
                return null;

            return new SettingUpdatesDTO
            {
                UpdateID = settingUpdates.UpdateID,
                Version = settingUpdates.Version,
                ServerMap = settingUpdates.ServerMap,
                FilesName = settingUpdates.FilesName,
                Date = settingUpdates.Date,
                Describe = settingUpdates.Describe,
            };
        }


        public static SettingGeneralsDTO ConvertToDto(this SettingGenerals settingGenerals)
        {
            if (settingGenerals == null)
                return null;

            return new SettingGeneralsDTO
            {
                SettingGeneralID = settingGenerals.SettingGeneralID,
                Version = settingGenerals.Version,
                FactoryNameEn = settingGenerals.FactoryNameEn,
                FactoryNameFa = settingGenerals.FactoryNameFa,
                CalendarCultureInfo = settingGenerals.CalendarCultureInfo,
                CurrencyDecimalSeparator = settingGenerals.CurrencyDecimalSeparator,
                ReportCustomerDraftFormCode = settingGenerals.ReportCustomerDraftFormCode,
                LogOpeningForm = Convert.ToBoolean(settingGenerals.LogOpeningForm),
                LogClosingForm = Convert.ToBoolean(settingGenerals.LogClosingForm),
                LogButtonsClick = Convert.ToBoolean(settingGenerals.LogButtonsClick),
                FactoryCode = settingGenerals.FactoryCode,


            };
        }

        public static MenuAccessStatesDTO ConvertToDto(this MenuAccessStates menuAccessStates)
        {
            if (menuAccessStates == null)
                //return new MenuAccessStatesDTO();
                return null;

            return new MenuAccessStatesDTO
            {
                MenuAccessStateID = menuAccessStates.MenuAccessStateID,
                MenuName = menuAccessStates.MenuName,
                MenuText = menuAccessStates.MenuText,
                State = menuAccessStates.State,
                MenuGroupID = menuAccessStates.MenuGroupID,
            };
        }

        public static DenyAccessesDTO ConvertToDto(this DenyAccesses denyAccesses)
        {
            if (denyAccesses == null)
                return null;

            return new DenyAccessesDTO
            {
                DenyAccessID = denyAccesses.DenyAccessID,
                UserID = denyAccesses.UserID,
                StationID = denyAccesses.StationID,
                MenuGroupID = denyAccesses.MenuGroupID,
                MenuID = denyAccesses.MenuID,
                MenuName = denyAccesses.MenuName,
                Caption = denyAccesses.Caption,
                CaptionPath = denyAccesses.CaptionPath,
                State = denyAccesses.State,
            };
        }

        public static LoginLogsDTO ConvertToDto(this LoginLogs loginLogs)
        {
            if (loginLogs == null)
                return null;

            return new LoginLogsDTO
            {
                LoginLogID = loginLogs.LoginLogID,
                UserID = loginLogs.UserID,
                User = loginLogs.User.ConvertToDto(),
                MachineName = loginLogs.MachineName,
                SystemUserName = loginLogs.SystemUserName,
                StationID = loginLogs.StationID,
                LoginDate = loginLogs.LoginDate,
                LoginTime = loginLogs.LoginTime,
                LogoutDate = loginLogs.LogoutDate,
                LogoutTime = loginLogs.LogoutTime,
                Version = loginLogs.Version,
                IPAddresses = loginLogs.IPAddresses,


            };
        }

        public static LogsDTO ConvertToDto(this Logs logs)
        {
            if (logs == null)
                return null;

            return new LogsDTO
            {
                LogID = logs.LogID,
                Date = logs.Date,
                Time = logs.Time,
                UserID = logs.UserID,
                User = logs.User.ConvertToDto(),
                Action = logs.Action,
                Details = logs.Details,
                LoginLogID = logs.LoginLogID,
                LoginLog = logs.LoginLog.ConvertToDto(),
                ServerDateTime = logs.ServerDateTime,
            };
        }

        public static AutoCompleteFieldDTO ConvertToDto(this AutoCompleteField autoCompleteField)
        {
            if (autoCompleteField == null)
                return null;

            return new AutoCompleteFieldDTO
            {
                AutoCompleteFieldID = autoCompleteField.AutoCompleteFieldID,
                FieldName = autoCompleteField.FieldName,
                FieldValue = autoCompleteField.FieldValue,


            };
        }


        #endregion

    }

    public static partial class ModelExtensions
    {


        #region ConvertToListDto


        public static List<SysUserDto> ConvertToListDto(this SysUserAccount token)
        {
            List<SysUserDto> list2 = new List<SysUserDto>();
            list2.Add(token.ConvertToDto());
            return list2;

        }

        public static List<UsersDTO> ConvertToListDto(this Users users)
        {
            List<UsersDTO> list2 = new List<UsersDTO>();
            list2.Add(users.ConvertToDto());
            return list2;
        }
        public static List<UsersDTO> ConvertToListDto(this List<Core.Models.Users> users)
        {
            if (users == null) return null;

            List<UsersDTO> list2 = new List<UsersDTO>();
            users.ForEach
                (s => list2.Add(s.ConvertToDto())
                );
            return list2;
        }


        public static List<ProvincesDTO> ConvertToListDto(this List<Core.Models.Provinces> province)
        {
            List<ProvincesDTO> list2 = new List<ProvincesDTO>();
            province.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        //public static List<CustomerDraftPaletsBobinsDTO> ConvertToListDto(this List<Core.Models.CustomerDraftPaletsBobins> customerDraftPaletsBobins)
        //{
        //    List<CustomerDraftPaletsBobinsDTO> list2 = new List<CustomerDraftPaletsBobinsDTO>();
        //    customerDraftPaletsBobins.ForEach(s => list2.Add(s.ConvertToDto()));
        //    return list2;
        //}


        public static List<DomainDTO> ConvertToListDto(this Domain domains)
        {
            List<DomainDTO> list2 = new List<DomainDTO>();
            list2.Add(domains.ConvertToDto());
            return list2;
        }
        public static List<DomainDTO> ConvertToListDto(this List<Core.Models.Domain> domains)
        {
            List<DomainDTO> list2 = new List<DomainDTO>();
            domains.ForEach
                (s => list2.Add(s.ConvertToDto())
                );
            return list2;
        }

        

        public static List<SettingUpdatesDTO> ConvertToListDto(this List<Core.Models.SettingUpdates> settingUpdates)
        {
            List<SettingUpdatesDTO> list2 = new List<SettingUpdatesDTO>();
            settingUpdates.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        public static List<SettingGeneralsDTO> ConvertToListDto(this List<Core.Models.SettingGenerals> settingGenerals)
        {
            List<SettingGeneralsDTO> list2 = new List<SettingGeneralsDTO>();
            settingGenerals.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<MenuAccessStatesDTO> ConvertToListDto(this List<Core.Models.MenuAccessStates> menuAccessStates)
        {
            List<MenuAccessStatesDTO> list2 = new List<MenuAccessStatesDTO>();
            menuAccessStates.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<DenyAccessesDTO> ConvertToListDto(this List<Core.Models.DenyAccesses> denyAccesses)
        {
            List<DenyAccessesDTO> list2 = new List<DenyAccessesDTO>();
            denyAccesses.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<LoginLogsDTO> ConvertToListDto(this List<Core.Models.LoginLogs> loginLogs)
        {
            List<LoginLogsDTO> list2 = new List<LoginLogsDTO>();
            loginLogs.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<LogsDTO> ConvertToListDto(this List<Core.Models.Logs> logs)
        {
            List<LogsDTO> list2 = new List<LogsDTO>();
            logs.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }

        public static List<AutoCompleteFieldDTO> ConvertToListDto(this List<Core.Models.AutoCompleteField> autoCompleteField)
        {
            List<AutoCompleteFieldDTO> list2 = new List<AutoCompleteFieldDTO>();
            autoCompleteField?.ForEach(s => list2.Add(s.ConvertToDto()));
            return list2;
        }


        #endregion


        #region other 

        #endregion
    }
}
//Weight
//NetWeight
//Describe
//PalletQty