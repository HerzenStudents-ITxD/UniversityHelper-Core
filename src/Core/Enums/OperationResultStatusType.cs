using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HerzenHelper.Core.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum OperationResultStatusType
{
  FullSuccess,
  PartialSuccess,
  Failed
}
