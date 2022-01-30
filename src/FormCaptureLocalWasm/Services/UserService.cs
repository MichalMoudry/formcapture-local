using FormCaptureLocalWasm.Models;

namespace FormCaptureLocalWasm.Services
{
    /// <summary>
    /// Service class for persistent handling of user in this app.
    /// </summary>
    public class UserService
    {
        private static UserService? _instance;

        public static UserService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserService();
                }
                return _instance;
            }
        }

        protected UserService()
        {

        }

        /// <summary>
        /// Method for handling users login.
        /// </summary>
        /// <param name="user">Instance of User class.</param>
        public void Login(User user)
        {
            User = user;
        }

        /// <summary>
        /// Method for handling users logout.
        /// </summary>
        public void Logout()
        {
            User = null;
        }

        /// <summary>
        /// Instance of a User class.
        /// </summary>
        public User? User { get; private set; }
    }
}
