using System;

namespace UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Requests;

public interface ICheckEventManagerRequest
{
  Guid UserId { get; }

  Guid EventId { get; }

  static object CreateObj(Guid userId, Guid eventId)
  {
    return new
    {
      UserId = userId,
      EventId = eventId
    };
  }
}
