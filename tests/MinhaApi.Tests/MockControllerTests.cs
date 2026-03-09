using System.Text.Json;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Controllers;

namespace MinhaApi.Tests
{
    public class MockControllerTests
    {
        private MockController CreateController()
        {
            var logger = new Mock<ILogger<MockController>>().Object;
            return new MockController(logger);
        }

        [Fact]
        public void Post_MissingEstado_ReturnsBadRequest()
        {
            var controller = CreateController();
            var json = JsonDocument.Parse("{\"nome\":\"x\"}").RootElement;
            var result = controller.Post(json);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_WELCOME_ReturnsOkWithComando()
        {
            var controller = CreateController();
            var json = JsonDocument.Parse("{\"Estado\":\"WELCOME\"}").RootElement;
            var result = controller.Post(json) as OkObjectResult;
            Assert.NotNull(result);
            var serialized = JsonSerializer.Serialize(result.Value);
            Assert.Contains("WELCOME", serialized);
        }
    }
}
