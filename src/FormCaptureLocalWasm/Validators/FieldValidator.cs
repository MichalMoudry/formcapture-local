using FluentValidation;
using FormCaptureLocalWasm.Models.DbModels;

namespace FormCaptureLocalWasm.Validators;

/// <summary>
/// Validator class for <see cref="Field" /> class.
/// </summary>
public sealed class FieldValidator : AbstractValidator<Field>
{
    public FieldValidator()
    {
        RuleFor(i => i.Name).NotNull().NotEmpty();
        RuleFor(i => i.Width).GreaterThan(0);
        RuleFor(i => i.Height).GreaterThan(0);
    }
}