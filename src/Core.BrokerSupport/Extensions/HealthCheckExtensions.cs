using UniversityHelper.Core.BrokerSupport.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace UniversityHelper.Core.BrokerSupport.Extensions;

public static class HealthCheckExtensions
{
  public static IHealthChecksBuilder AddRabbitMqCheck(this IHealthChecksBuilder builder)
  {
    return builder.AddCheck<RabbitMqHealthCheck>("RabbitMQ");
  }
}
