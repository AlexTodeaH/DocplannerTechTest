namespace DocplannerTechTest.Application.Features.Availability.Models
{
    public class AvailabilityResponse
    {
        public Facility Facility { get; set; }
        public int SlotDurationMinutes { get; set; }
        public Dictionary<string, DayAvailability> WeeklyAvailability { get; set; }
    }

    public class Facility
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class DayAvailability
    {
        public WorkPeriod WorkPeriod { get; set; }
        public List<BusySlot> BusySlots { get; set; }
    }

    public class WorkPeriod
    {
        public int StartHour { get; set; }
        public int LunchStartHour { get; set; }
        public int LunchEndHour { get; set; }
        public int EndHour { get; set; }
    }

    public class BusySlot
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}