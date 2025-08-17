using System.Text.Json;

namespace Api_OsteoHealth_Tesis.Utils
{
    public class Utils
    {
        public static readonly JsonSerializerOptions JsonOpts = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static string SafeSerialize(object? data)
        {
            try { return JsonSerializer.Serialize(data ?? new { }, JsonOpts); }
            catch { return "{}"; } // fallback si vino algo no serializable
        }

        public static object SafeDeserialize(string json)
        {
            try { return JsonSerializer.Deserialize<object>(json, JsonOpts) ?? new { }; }
            catch { return json; } // si está corrupto, devolvemos el string crudo
        }

        public static JsonDocument ParseJsonOrEmpty(string? json)
        {
            if (string.IsNullOrWhiteSpace(json)) return JsonDocument.Parse("{}");
            try { return JsonDocument.Parse(json); }
            catch { return JsonDocument.Parse("{}"); } // o relanzar según tu política
        }
    }
}
