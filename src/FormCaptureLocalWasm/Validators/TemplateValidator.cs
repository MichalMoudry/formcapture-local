using FluentValidation;
using FormCaptureLocalWasm.Models.DbModels;

namespace FormCaptureLocalWasm.Validators;

/// <summary>
/// Validator class for <see cref="Template" /> class.
/// </summary>
public sealed class TemplateValidator : AbstractValidator<Template>
{
    public TemplateValidator()
    {
        RuleFor(i => i.Name).NotNull().NotEmpty();
        RuleFor(i => i.Image).NotNull();
        RuleFor(i => i.Xdimension).GreaterThan(0);
        RuleFor(i => i.Ydimension).GreaterThan(0);
        RuleFor(i => i.ContentType).NotNull().NotEmpty();
    }
}