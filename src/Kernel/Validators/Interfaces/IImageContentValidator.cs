using FluentValidation;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.Core.Validators.Interfaces;

[AutoInject]
public interface IImageContentValidator : IValidator<string>
{
}
