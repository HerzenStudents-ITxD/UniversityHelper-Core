using UniversityHelper.Core.BrokerSupport.TextTemplateModels.Requests;
using UniversityHelper.Core.BrokerSupport.Attributes;
using UniversityHelper.Core.BrokerSupport.Configurations;

namespace UniversityHelper.Core.BrokerSupport.Configurations;

public class ExtendedBaseRabbitMqConfig : BaseRabbitMqConfig
{
  [AutoInjectRequest(typeof(ICreateKeywordsRequest))]
  public virtual string CreateKeywordsEndpoint { get; init; }
}
