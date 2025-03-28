﻿using UniversityHelper.Core.Attributes;
using System;
using System.Collections.Generic;

namespace UniversityHelper.Core.RedisSupport.Helpers.Interfaces;

[AutoInject]
public interface ICacheNotebook
{
  void Add(List<Guid> elementsIds, int database, string key);
  void Add(Guid elementId, int database, string key);
  IEnumerable<(int database, string key)> GetKeys(Guid elementId);
  IEnumerable<(int database, string key)> GetKeys();
  void Remove(Guid elementId);
  void Clear();
}
