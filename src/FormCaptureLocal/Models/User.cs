using System;

namespace FormCaptureLocal.Models
{
    public record User
    {
        public string Email { get; set; }

        public DateTime LastLogin { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}