using System.ComponentModel.DataAnnotations;

namespace FormCaptureLocalWasm.Models;

public sealed class User
{
    public int ID { get; set; }

    [Required, EmailAddress]
    public string? Email { get; set; }

    public DateTime LastLogin { get; set; }

    [Required]
    public string? Password { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }
}
