﻿using UniversityHelper.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityHelper.Core.RedisSupport.Helpers.Interfaces;

[AutoInject]
public interface IRedisHelper
{
  Task<bool> CreateAsync<T>(int database, string key, T item, TimeSpan? lifeTime = null);
  Task<T> GetAsync<T>(int database, string key);
  Task<bool> RemoveAsync(List<(int database, string key)> elements);
}
