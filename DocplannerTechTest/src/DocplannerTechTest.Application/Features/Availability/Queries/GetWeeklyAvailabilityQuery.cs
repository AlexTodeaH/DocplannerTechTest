using MediatR;

namespace DocplannerTechTest.Application.Features.Availability.Queries
{
    public class GetWeeklyAvailabilityQuery : IRequest<string>
    {
        public string Date { get; set; }
    }
}