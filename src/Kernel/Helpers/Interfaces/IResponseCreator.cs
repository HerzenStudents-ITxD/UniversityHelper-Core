using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using System.Collections.Generic;
using System.Net;

namespace HerzenHelper.Core.Helpers.Interfaces;

[AutoInject]
public interface IResponseCreator
{
  OperationResultResponse<T> CreateFailureResponse<T>(HttpStatusCode statusCode, List<string> errors = null);
  FindResultResponse<T> CreateFailureFindResponse<T>(HttpStatusCode statusCode, List<string> errors = null);
}
