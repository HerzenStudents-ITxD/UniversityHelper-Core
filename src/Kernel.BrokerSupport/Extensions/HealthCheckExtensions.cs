using HerzenHelper.Core.BrokerSupport.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace HerzenHelper.Core.BrokerSupport.Extensions;

public static class HealthCheckExtensions
{
  public static IHealthChecksBuilder AddRabbitMqCheck(this IHealthChecksBuilder builder)
  {
    return builder.AddCheck<RabbitMqHealthCheck>("RabbitMQ");
  }
}
