using FluentValidation;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.Core.Validators.Interfaces;

[AutoInject]
public interface IImageContentValidator : IValidator<string>
{
}
