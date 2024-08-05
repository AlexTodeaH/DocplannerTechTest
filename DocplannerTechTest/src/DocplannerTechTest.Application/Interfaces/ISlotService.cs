using DocplannerTechTest.Application.Features.Availability.Models;

namespace DocplannerTechTest.Application.Interfaces
{
    public interface ISlotService
    {
        Task<string> GetWeeklyAvailability(string date);
        Task TakeSlot(TakeSlotRequest slotRequest);
    }
}
