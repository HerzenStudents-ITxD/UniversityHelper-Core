﻿using MassTransit;
using System;

namespace UniversityHelper.Core.BrokerSupport.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class AutoInjectRequestAttribute : Attribute
{
  public Type Model { get; init; }
  public RequestTimeout Timeout { get; init; }

  public AutoInjectRequestAttribute(
    Type model,
    uint timeout = 0)
  {
    Model = model;

    if (timeout > 0)
    {
      Timeout = RequestTimeout.After(ms: (int)timeout);
    }
    else
    {
      Timeout = RequestTimeout.Default;
    }
  }
}
