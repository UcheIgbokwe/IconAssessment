using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Behaviours;
using Xunit;

namespace Tests.UnitTests.Application
{
    public class HttpStatusExceptionTests
    {
        [Fact]
        public void SomeMethodShouldThrowHttpStatusException()
        {
            static void Act() => throw new HttpStatusException();

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<HttpStatusException>(ex);
        }

        [Fact]
        public void SomeMethodShouldThrowHttpStatusExceptionWithParameter()
        {
            static void Act() => throw new HttpStatusException("Test");

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<HttpStatusException>(ex);
        }
    }
}