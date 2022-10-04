using FluentValidation;
using FormCaptureLocalWasm.Models;

namespace FormCaptureLocalWasm.Validators;

/// <summary>
/// Validator class for <see cref="User" /> class.
/// </summary>
public sealed class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(i => i.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(i => i.Password).NotNull().NotEmpty().MinimumLength(5);
    }
}