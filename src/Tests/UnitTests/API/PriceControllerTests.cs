using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Application.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests.UnitTests.API
{
    public class PriceControllerTests
    {
        private readonly PriceController  sut;
        private readonly Mock<IMediator> mediator;
        public PriceControllerTests()
        {
            mediator = new Mock<IMediator>();
            sut = new PriceController(mediator.Object);
        }

        [Fact]
        public async void   Post_ShouldReturn_Null()
        {
            var result = await sut.GetBestRate(It.IsAny<GetPriceCommand>());

            Assert.IsType<NotFoundResult>(result);
        }
    }
}