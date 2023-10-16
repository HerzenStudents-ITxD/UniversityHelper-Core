using HerzenHelper.Core.Enums;
using System;

namespace HerzenHelper.Core.Attributes;

[AttributeUsage(AttributeTargets.Interface)]
public class AutoInjectAttribute : Attribute
{
  public InjectType InjectType { get; init; }

  public AutoInjectAttribute(InjectType type = InjectType.Transient)
  {
    InjectType = type;
  }
}
