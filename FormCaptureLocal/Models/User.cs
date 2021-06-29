using FormCaptureLocal.Models.Util;
using System;

namespace FormCaptureLocal.Models
{
    public class User : Model
    {
        public string Email { get; set; }

        public DateTime LastLogin { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}