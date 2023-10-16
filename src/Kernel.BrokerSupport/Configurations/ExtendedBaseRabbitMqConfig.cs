using HerzenHelper.Core.BrokerSupport.TextTemplateModels.Requests;
using HerzenHelper.Core.BrokerSupport.Attributes;
using HerzenHelper.Core.BrokerSupport.Configurations;

namespace HerzenHelper.Core.BrokerSupport.Configurations;

public class ExtendedBaseRabbitMqConfig : BaseRabbitMqConfig
{
  [AutoInjectRequest(typeof(ICreateKeywordsRequest))]
  public virtual string CreateKeywordsEndpoint { get; init; }
}
