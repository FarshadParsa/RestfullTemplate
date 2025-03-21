namespace PPC.Common.Auth
{
    /// <summary>
    /// IUser
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Id
        /// </summary>
        string Id { get; }

        /// <summary>
        /// NickName
        /// </summary>
        string NickName { get; }

        /// <summary>
        /// Username
        /// </summary>
        string Username { get; }    
        
        /// <summary>
        /// Username
        /// </summary>
        string SerialNumber { get; }


    }
}
