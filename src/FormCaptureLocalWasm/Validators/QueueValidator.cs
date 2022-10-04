using FluentValidation;
using FormCaptureLocalWasm.Models.DbModels;

namespace FormCaptureLocalWasm.Validators;

/// <summary>
/// Validator class for <see cref="Queue" /> class.
/// </summary>
public sealed class QueueValidator : AbstractValidator<Queue>
{
    public QueueValidator()
    {
        RuleFor(i => i.Name).NotNull().NotEmpty().MinimumLength(2);
        RuleFor(i => i.Locale).NotNull().NotEmpty();
    }
}