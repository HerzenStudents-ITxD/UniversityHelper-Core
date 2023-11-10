using System;

namespace UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Requests;

public interface ICheckCommunityManagerRequest
{
  Guid UserId { get; }

  Guid CommunityId { get; }

  static object CreateObj(Guid userId, Guid communityId)
  {
    return new
    {
      UserId = userId,
      CommunityId = communityId
    };
  }
}
