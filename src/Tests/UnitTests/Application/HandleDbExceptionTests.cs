using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Behaviours;
using Xunit;

namespace Tests.UnitTests.Application
{
    public class HandleDbExceptionTests
    {
        [Fact]
        public void SomeMethodShouldThrowHandleDbException()
        {
            static void Act() => throw new HandleDbException();

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<HandleDbException>(ex);
        }

        [Fact]
        public void SomeMethodShouldThrowHandleDbExceptionWithParameter()
        {
            static void Act() => throw new HandleDbException("Test");

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<HandleDbException>(ex);
        }
    }
}