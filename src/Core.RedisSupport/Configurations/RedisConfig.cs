﻿namespace UniversityHelper.Core.RedisSupport.Configurations;

public class RedisConfig
{
  public const string SectionName = "Redis";

  public double CacheLiveInMinutes { get; set; }
}
