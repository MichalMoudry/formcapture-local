using FluentValidation;
using FormCaptureLocalWasm.Models.DbModels;

namespace FormCaptureLocalWasm.Validators;

/// <summary>
/// Validator class for <see cref="ProcessedFile" /> class.
/// </summary>
public sealed class ProcessedFileValidator : AbstractValidator<ProcessedFile>
{
    public ProcessedFileValidator()
    {
        RuleFor(i => i.Name).NotNull().NotEmpty();
        RuleFor(i => i.Content).NotNull().NotEmpty();
        RuleFor(i => i.BlackAndWhiteContent).NotNull().NotEmpty();
        RuleFor(i => i.ContentType).NotNull().NotEmpty();
    }
}