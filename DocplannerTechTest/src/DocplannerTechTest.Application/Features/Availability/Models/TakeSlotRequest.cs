using DocplannerTechTest.Application.Converters;
using System.Text.Json.Serialization;

namespace DocplannerTechTest.Application.Features.Availability.Models
{
    public class TakeSlotRequest
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Start { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime End { get; set; }
        public string Comments { get; set; }
        public PatientModel Patient { get; set; }
    }

    public class PatientModel
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}