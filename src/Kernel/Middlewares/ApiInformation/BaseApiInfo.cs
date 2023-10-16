using HerzenHelper.Core.Extensions;
using System;

namespace HerzenHelper.Core.Middlewares.ApiInformation;

public abstract class BaseApiInfo
{
  public static string Version { get; protected set; }
  public static DateTime StartTime { get; protected set; }
  public static string ApiName { get; protected set; }
  public static string Description { get; protected set; }

  public static object GetResponse()
  {
    return new
    {
      ApiName,
      Version,
      Description,
      UpTime = StartTime.ToServiceUpTime()
    };
  }
}
