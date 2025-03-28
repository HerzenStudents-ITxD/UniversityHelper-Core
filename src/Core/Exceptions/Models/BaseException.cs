﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityHelper.Core.Exceptions.Models;

/// <summary>
/// Indicates client or server error.
/// </summary>
public abstract class BaseException : Exception
{
  /// <summary>
  /// Status code is issued by a server in response to a client's request made to the server.
  /// </summary>
  public virtual int StatusCode { get; }

  /// <summary>
  /// An explanatory phrase in English that explains to a person the reason for just such an answer.
  /// </summary>
  public virtual string Header { get; }

  protected BaseException()
  {
  }

  protected BaseException(string message) : base(message)
  {
  }

  protected BaseException(IEnumerable<string> messages) : base(new StringBuilder().AppendJoin("\n", messages).ToString())
  {
  }

  protected BaseException(string message, Exception inner) : base(message, inner)
  {
  }

  protected BaseException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
    : base(info, context)
  {
  }
}
