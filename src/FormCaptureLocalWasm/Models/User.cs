using System.ComponentModel.DataAnnotations;

namespace FormCaptureLocalWasm.Models;

public class User
{
    [Required, EmailAddress]
    public string? Email { get; set; }

    public DateTime LastLogin { get; set; }

    [Required]
    public string? Password { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }
}
