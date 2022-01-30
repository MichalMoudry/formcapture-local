using FormCaptureLocalWasm.Models;

namespace FormCaptureLocalWasm.Services
{
    /// <summary>
    /// Interface for user service classes.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method for handling users login (= saving information about who logged in and duration of login).
        /// </summary>
        /// <param name="user">Instance of User class.</param>
        Task Login(User user);

        /// <summary>
        /// Method for handling users logout (= removing information about who logged in and duration of login).
        /// </summary>
        /// <param name="email">User's email.</param>
        Task Logout(string email);

        /// <summary>
        /// Instance of a User class.
        /// </summary>
        public User? User { get; }
    }
}
