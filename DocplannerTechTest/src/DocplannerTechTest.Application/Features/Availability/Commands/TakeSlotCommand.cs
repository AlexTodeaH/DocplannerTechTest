using DocplannerTechTest.Application.Features.Availability.Models;
using MediatR;

namespace DocplannerTechTest.Application.Features.Availability.Commands
{
    public class TakeSlotCommand : IRequest
    {
        public TakeSlotRequest SlotRequest { get; set; }
    }
}