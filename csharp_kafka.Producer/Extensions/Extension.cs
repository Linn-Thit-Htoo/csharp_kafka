using Newtonsoft.Json;

namespace csharp_kafka.Producer.Extensions;

public static class Extension
{
    public static string ToJson(this object obj) =>
        JsonConvert.SerializeObject(obj, Formatting.Indented);
}
