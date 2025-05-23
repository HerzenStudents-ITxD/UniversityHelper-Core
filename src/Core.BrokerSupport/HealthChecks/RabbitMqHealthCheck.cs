﻿using UniversityHelper.Core.BrokerSupport.Configurations;
using UniversityHelper.Core.Configurations;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UniversityHelper.Core.BrokerSupport.HealthChecks;

public class RabbitMqHealthCheck : IHealthCheck
{
  private readonly ILogger<RabbitMqHealthCheck> _logger;
  private readonly BaseRabbitMqConfig _rabbitMqConfig;
  private readonly BaseServiceInfoConfig _serviceInfoConfig;

  public RabbitMqHealthCheck(
    ILogger<RabbitMqHealthCheck> logger,
    IOptions<BaseRabbitMqConfig> rabbitMqConfig,
    IOptions<BaseServiceInfoConfig> serviceInfoConfig)
  {
    _logger = logger;
    _rabbitMqConfig = rabbitMqConfig?.Value;
    _serviceInfoConfig = serviceInfoConfig?.Value;

    if (_rabbitMqConfig == null)
    {
      throw new ArgumentNullException(nameof(rabbitMqConfig));
    }

    if (_serviceInfoConfig == null)
    {
      throw new ArgumentNullException(nameof(serviceInfoConfig));
    }
  }

  public Task<HealthCheckResult> CheckHealthAsync(
    HealthCheckContext context,
    CancellationToken cancellationToken = default)
  {
    try
    {
      string name = _rabbitMqConfig.Username ?? $"{_serviceInfoConfig.Name}_{_serviceInfoConfig.Id}";
      string password = _rabbitMqConfig.Password ?? _serviceInfoConfig.Id;

      var factory = new ConnectionFactory
      {
        RequestedConnectionTimeout = TimeSpan.FromMilliseconds(200),
        Uri = new Uri(
          $"amqp://{name}:{password}@{_rabbitMqConfig.Host}:5672/"),
      };

      IConnection con = factory.CreateConnection();
      con.Close();

      return Task.FromResult(
        HealthCheckResult.Healthy("Connection to RabbitMQ was established successfully."));
    }
    catch (Exception exc)
    {
      string errorMessage = "RabbitMQ is unreachable.";

      _logger.LogError(exc, errorMessage);

      return Task.FromResult(new HealthCheckResult(
        context.Registration.FailureStatus,
        errorMessage));
    }
  }
}
