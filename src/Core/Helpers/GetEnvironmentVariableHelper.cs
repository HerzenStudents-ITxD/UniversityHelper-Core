﻿using UniversityHelper.Core.Exceptions.Models;
using System;

namespace UniversityHelper.Core.Helpers;

public static class GetEnvironmentVariableHelper
{
  public static string Get(string key)
  {
    return Environment.GetEnvironmentVariable(key)
      ?? throw new InternalServerException($"No environment variable named {key}");
  }
}
