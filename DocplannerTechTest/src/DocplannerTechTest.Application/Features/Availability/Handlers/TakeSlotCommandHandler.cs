using DocplannerTechTest.Application.Features.Availability.Commands;
using DocplannerTechTest.Application.Interfaces;
using MediatR;

namespace DocplannerTechTest.Application.Features.Availability.Handlers
{
    public class TakeSlotCommandHandler : IRequestHandler<TakeSlotCommand>
    {
        private readonly ISlotService _slotService;

        public TakeSlotCommandHandler(ISlotService slotService)
        {
            _slotService = slotService;
        }

        public async Task Handle(TakeSlotCommand request, CancellationToken cancellationToken)
        {
            await _slotService.TakeSlot(request.SlotRequest);
        }
    }
}