using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Requests;
using HerzenHelper.Core.BrokerSupport.Attributes;
using HerzenHelper.Core.BrokerSupport.Middlewares.Token;
using System;

namespace HerzenHelper.Core.BrokerSupport.Configurations;

/// <summary>
/// Base configuration class for RabbitMQ.
/// </summary>
public class BaseRabbitMqConfig
{
  public const string SectionName = "RabbitMQ";

  private const string RabbitMqProtocol = "rabbitmq";

  public string BaseUrl => $"{RabbitMqProtocol}://{Host}";

  private string host = Environment.GetEnvironmentVariable("RabbitMQ_Host");
  public string Host
  {
    get
    {
      return host;
    }
    init
    {
      if (string.IsNullOrWhiteSpace(host))
      {
        host = value;
      }
    }
  }

  private string virtualHost = Environment.GetEnvironmentVariable("RabbitMQ_VirtualHost");
  public string VirtualHost
  {
    get
    {
      return virtualHost;
    }
    init
    {
      if (string.IsNullOrWhiteSpace(virtualHost))
      {
        virtualHost = value;
      }
    }
  }

  private string username = Environment.GetEnvironmentVariable("RabbitMQ_Username");
  public string Username
  {
    get
    {
      return username;
    }
    init
    {
      if (string.IsNullOrWhiteSpace(username))
      {
        username = value;
      }
    }
  }

  private string password = Environment.GetEnvironmentVariable("RabbitMQ_Password");
  public string Password
  {
    get
    {
      return password;
    }
    init
    {
      if (string.IsNullOrWhiteSpace(password))
      {
        password = value;
      }
    }
  }

  [AutoInjectRequest(typeof(ICheckUserIsAdminRequest))]
  public virtual string CheckUserIsAdminEndpoint { get; init; }

  [AutoInjectRequest(typeof(ICheckUserRightsRequest))]
  public virtual string CheckUserRightsEndpoint { get; init; }

  [AutoInjectRequest(typeof(ICheckUserAnyRightRequest))]
  public virtual string CheckUserAnyRightEndpoint { get; init; }

  [AutoInjectRequest(typeof(ICheckTokenRequest))]
  public virtual string ValidateTokenEndpoint { get; init; }

  [AutoInjectRequest(typeof(ICheckEventManagerRequest))]
  public virtual string CheckEventManagerEndpoint { get; init; }

  [AutoInjectRequest(typeof(ICheckCommunityManagerRequest))]
  public virtual string CheckCommunityManagerEndpoint { get; init; }
}
