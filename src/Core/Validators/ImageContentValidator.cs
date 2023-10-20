using FluentValidation;
using HerzenHelper.Core.Validators.Interfaces;
using System;

namespace HerzenHelper.Core.Validators;

public class ImageContentValidator : AbstractValidator<string>, IImageContentValidator
{
  public ImageContentValidator()
  {
    RuleFor(content => content)
      .Cascade(CascadeMode.Stop)
      .NotEmpty().WithMessage("Content can't be empty.")
      .Must(content => Convert.TryFromBase64String(content, new Span<byte>(new byte[content.Length]), out _))
      .WithMessage("Content must be base64 string.");
  }
}
