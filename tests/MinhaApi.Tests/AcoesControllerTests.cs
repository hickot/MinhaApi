using System;
using Xunit;
using MinhaApi.Controllers;

namespace MinhaApi.Tests
{
    public class AcoesControllerTests
    {
        [Fact]
        public void CapturarEstado_ReturnsEstadoWhenPresent()
        {
            string json = "{\"estado\":\"WELCOME\"}";
            var estado = AcoesController.CapturarEstado(json);
            Assert.Equal("WELCOME", estado);
        }

        [Fact]
        public void CapturarEstado_ReturnsNullWhenMissing()
        {
            string json = "{\"nope\":\"x\"}";
            var estado = AcoesController.CapturarEstado(json);
            Assert.Null(estado);
        }
    }
}
