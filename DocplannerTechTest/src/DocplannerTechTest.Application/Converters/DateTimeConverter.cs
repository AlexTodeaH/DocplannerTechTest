using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocplannerTechTest.Application.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DATE_FORMAT));
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), DATE_FORMAT, null);
        }
    }
}