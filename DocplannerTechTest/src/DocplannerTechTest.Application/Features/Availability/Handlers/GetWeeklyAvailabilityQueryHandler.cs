using DocplannerTechTest.Application.Features.Availability.Queries;
using DocplannerTechTest.Application.Interfaces;
using MediatR;

namespace DocplannerTechTest.Application.Features.Availability.Handlers
{
    public class GetWeeklyAvailabilityQueryHandler : IRequestHandler<GetWeeklyAvailabilityQuery, string>
    {
        private readonly ISlotService _slotService;

        public GetWeeklyAvailabilityQueryHandler(ISlotService slotService)
        {
            _slotService = slotService;
        }

        public async Task<string> Handle(GetWeeklyAvailabilityQuery request, CancellationToken cancellationToken)
        {
            return await _slotService.GetWeeklyAvailability(request.Date);
        }
    }
}