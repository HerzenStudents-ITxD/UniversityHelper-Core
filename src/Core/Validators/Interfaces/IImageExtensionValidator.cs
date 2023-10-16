using FluentValidation;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.Core.Validators.Interfaces;

[AutoInject]
public interface IImageExtensionValidator : IValidator<string>
{
}
