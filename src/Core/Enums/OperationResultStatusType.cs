using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UniversityHelper.Core.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum OperationResultStatusType
{
  FullSuccess,
  PartialSuccess,
  Failed
}
