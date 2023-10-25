using HerzenHelper.Core.BrokerSupport.Configurations;
using HerzenHelper.Core.BrokerSupport.TextTemplateModels;
using HerzenHelper.Core.BrokerSupport.TextTemplateModels.Requests;
using HerzenHelper.Core.BrokerSupport.Helpers;
using HerzenHelper.Core.EndpointSupport.Helpers;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerzenHelper.Core.EndpointSupport.Broker;

public static class KeywordSender
{
  public static async Task Send(
    this IApplicationBuilder app,
    ExtendedBaseRabbitMqConfig rabbitConfig)
  {
    Dictionary<Guid, List<string>> endpointsKeywords = KeywordCollector
      .GetEndpointKeywords();

    if (endpointsKeywords.Any())
    {
      List<EndpointKeywords> requestData = new();

      foreach (var endpointKeywords in endpointsKeywords)
      {
        requestData.Add(
          new EndpointKeywords(
            endpointId: endpointKeywords.Key,
            keywords: endpointKeywords.Value));
      }

      await RequestHandler.ProcessRequest<ICreateKeywordsRequest, bool>(
        app.CreateRc<ICreateKeywordsRequest>(rabbitConfig, rabbitConfig.CreateKeywordsEndpoint),
        ICreateKeywordsRequest.CreateObj(requestData));
    }
  }
}
