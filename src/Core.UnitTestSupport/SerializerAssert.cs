using NUnit.Framework;
using System.Text.Json;

namespace HerzenHelper.Core.UnitTestSupport;
public static class SerializerAssert
{
  public static void AreEqual(object expected, object result)
  {
    string expected2 = JsonSerializer.Serialize(expected);
    string actual = JsonSerializer.Serialize(result);
    Assert.AreEqual(expected2, actual);
  }

  public static void AreNotEqual(object expected, object result)
  {
    string expected2 = JsonSerializer.Serialize(expected);
    string actual = JsonSerializer.Serialize(result);
    Assert.AreNotEqual(expected2, actual);
  }
}