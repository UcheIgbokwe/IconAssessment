using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests.UnitTests.API
{
    public class AccountControllerTests
    {
        private readonly AccountController  sut;
        private readonly Mock<IUserService> userService;
        public AccountControllerTests()
        {
            userService = new Mock<IUserService>();
            sut = new AccountController(userService.Object);
        }

        [Fact]
        public void Authenticate_ShouldReturn_Unauthorized()
        {
            var result = sut.Authenticate(It.IsAny<AuthenticateRequest>());

            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}