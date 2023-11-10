using System;

namespace UniversityHelper.Core.BrokerSupport.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class MassTransitEndpointAttribute : Attribute
{
  public Type ConsumerType { get; }

  public MassTransitEndpointAttribute(Type consumerType)
  {
    ConsumerType = consumerType;
  }
}
