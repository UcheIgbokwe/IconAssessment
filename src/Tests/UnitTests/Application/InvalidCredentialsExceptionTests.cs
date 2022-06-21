using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Behaviours;
using Xunit;

namespace Tests.UnitTests.Application
{
    public class InvalidCredentialsExceptionTests
    {
        [Fact]
        public void SomeMethodShouldThrowInvalidCredentialsException()
        {
            static void Act() => throw new InvalidCredentialsException();

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<InvalidCredentialsException>(ex);
        }

        [Fact]
        public void SomeMethodShouldThrowInvalidCredentialsExceptionWithParameter()
        {
            static void Act() => throw new InvalidCredentialsException("Test");

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<HttpStatusException>(ex);
        }
    }
}