using UniversityHelper.Core.Enums;
using System;

namespace UniversityHelper.Core.Attributes;

[AttributeUsage(AttributeTargets.Interface)]
public class AutoInjectAttribute : Attribute
{
  public InjectType InjectType { get; init; }

  public AutoInjectAttribute(InjectType type = InjectType.Transient)
  {
    InjectType = type;
  }
}
