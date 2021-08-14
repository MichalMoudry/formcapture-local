namespace FormCaptureLocal.Models
{
    public class RegistrationModel
    {
        public string ConfirmationPassword { get; set; }

        public string Password { get; set; }

        public User User { get; set; }
    }
}