using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Tests
{
    public class ProdutosControllerTests
    {
        private ProdutosController CreateController()
        {
            var logger = new Mock<ILogger<ProdutosController>>().Object;
            return new ProdutosController(logger);
        }

        [Fact]
        public void Get_ReturnsAllProducts()
        {
            var controller = CreateController();
            var result = controller.Get() as OkObjectResult;
            Assert.NotNull(result);
            var list = Assert.IsType<System.Collections.Generic.List<string>>(result.Value);
            Assert.True(list.Count >= 3);
        }

        [Fact]
        public void Get_ByValidId_ReturnsProduct()
        {
            var controller = CreateController();
            var result = controller.Get(0) as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<string>(result.Value);
        }

        [Fact]
        public void Get_ByInvalidId_ReturnsNotFound()
        {
            var controller = CreateController();
            var result = controller.Get(-1);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_AddsProduct_AndCleansUp()
        {
            var controller = CreateController();
            var before = ((System.Collections.Generic.List<string>)((OkObjectResult)controller.Get()).Value).Count;
            var created = controller.Post("ProdutoTeste") as CreatedAtActionResult;
            Assert.NotNull(created);
            var after = ((System.Collections.Generic.List<string>)((OkObjectResult)controller.Get()).Value).Count;
            Assert.Equal(before + 1, after);
            // cleanup
            var deleteResult = controller.Delete(after - 1);
            Assert.IsType<NoContentResult>(deleteResult);
        }
    }
}
