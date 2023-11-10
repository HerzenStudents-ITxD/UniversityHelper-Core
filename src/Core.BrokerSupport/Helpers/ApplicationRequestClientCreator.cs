using UniversityHelper.Core.BrokerSupport.Configurations;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace UniversityHelper.Core.BrokerSupport.Helpers;

public static class ApplicationRequestClientCreator
{
  public static IRequestClient<T> CreateRc<T>(
    this IApplicationBuilder app,
    BaseRabbitMqConfig rabbitConfig,
    string endpoint) where T : class
  {
    IServiceProvider serviceProvider = app
      .ApplicationServices
      .GetRequiredService<IServiceProvider>();

    return serviceProvider
      .CreateRequestClient<T>(new Uri($"{rabbitConfig.BaseUrl}/{endpoint}"));
  }
}
