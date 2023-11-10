using FluentValidation;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.Core.Validators.Interfaces;

[AutoInject]
public interface IImageExtensionValidator : IValidator<string>
{
}
