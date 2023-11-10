using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using System.Collections.Generic;
using System.Net;

namespace UniversityHelper.Core.Helpers.Interfaces;

[AutoInject]
public interface IResponseCreator
{
  OperationResultResponse<T> CreateFailureResponse<T>(HttpStatusCode statusCode, List<string> errors = null);
  FindResultResponse<T> CreateFailureFindResponse<T>(HttpStatusCode statusCode, List<string> errors = null);
}
