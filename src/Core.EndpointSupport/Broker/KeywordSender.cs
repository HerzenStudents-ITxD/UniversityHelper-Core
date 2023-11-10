using UniversityHelper.Core.BrokerSupport.Configurations;
using UniversityHelper.Core.BrokerSupport.TextTemplateModels;
using UniversityHelper.Core.BrokerSupport.TextTemplateModels.Requests;
using UniversityHelper.Core.BrokerSupport.Helpers;
using UniversityHelper.Core.EndpointSupport.Helpers;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityHelper.Core.EndpointSupport.Broker;

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
