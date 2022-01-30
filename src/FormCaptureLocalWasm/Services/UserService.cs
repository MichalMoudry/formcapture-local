using Blazored.LocalStorage;
using FormCaptureLocalWasm.Models;

namespace FormCaptureLocalWasm.Services
{
    /// <summary>
    /// Service class for persistent handling of user in this app.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Private field with an instance of <see cref="ILocalStorageService"/>, that is used for accessing local storage.
        /// </summary>
        private readonly ILocalStorageService _localStorage;

        /// <summary>
        /// Constructor of this class.
        /// </summary>
        /// <param name="localStorage">Instance of <see cref="ILocalStorageService"/> obtained through DI.</param>
        public UserService(ILocalStorageService localStorage) => _localStorage = localStorage;

        public async Task Login(User user)
        {
            User = user;
            await _localStorage.SetItemAsStringAsync("user", user.Email);
            await _localStorage.SetItemAsync<DateTime>("duration", DateTime.Now.AddHours(1));
        }

        public async Task Logout(string email)
        {
            await _localStorage.RemoveItemAsync("user");
            await _localStorage.RemoveItemAsync("duration");
        }

        public User? User { get; private set; }
    }
}
