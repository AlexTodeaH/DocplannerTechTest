using DocplannerTechTest.Api.Controllers;
using DocplannerTechTest.Application.Features.Availability.Commands;
using DocplannerTechTest.Application.Features.Availability.Models;
using DocplannerTechTest.Application.Features.Availability.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DocplannerTechTest.Api.Tests.Controllers
{
    public class AvailabilityControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly AvailabilityController _controller;

        public AvailabilityControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AvailabilityController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetWeeklyAvailability_ReturnsOkResult()
        {
            var date = "2024-08-01";
            var expectedResult = "{\"Facility\": {\"Name\": \"Test Facility\", \"Address\": \"123 Test St\"}, \"SlotDurationMinutes\": 30, \"Monday\": {\"WorkPeriod\": {\"StartHour\": 8, \"LunchStartHour\": 12, \"LunchEndHour\": 13, \"EndHour\": 17}, \"BusySlots\": []}}";

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetWeeklyAvailabilityQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var result = await _controller.GetWeeklyAvailability(date) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public async Task TakeSlot_ReturnsOkResult()
        {
            var slotRequest = new TakeSlotRequest
            {
                Start = new DateTime(2017, 6, 13, 11, 0, 0),
                End = new DateTime(2017, 6, 13, 12, 0, 0),
                Comments = "My arm hurts a lot",
                Patient = new PatientModel
                {
                    Name = "Mario",
                    SecondName = "Neta",
                    Email = "mario.neta@example.com",
                    Phone = "555 44 33 22"
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<TakeSlotCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var result = await _controller.TakeSlot(slotRequest) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task TakeSlot_ReturnsInternalServerError()
        {
            var slotRequest = new TakeSlotRequest
            {
                Start = new DateTime(2017, 6, 13, 11, 0, 0),
                End = new DateTime(2017, 6, 13, 12, 0, 0),
                Comments = "My arm hurts a lot"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<TakeSlotCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Test exception"));

            var result = await _controller.TakeSlot(slotRequest) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
    }
}
