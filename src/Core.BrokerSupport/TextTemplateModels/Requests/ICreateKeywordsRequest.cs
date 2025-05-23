﻿using System.Collections.Generic;

namespace UniversityHelper.Core.BrokerSupport.TextTemplateModels.Requests;

public interface ICreateKeywordsRequest
{
  List<EndpointKeywords> EndpointsKeywords { get; }

  static object CreateObj(List<EndpointKeywords> endpointsKeywords)
  {
    return new
    {
      EndpointsKeywords = endpointsKeywords
    };
  }
}
