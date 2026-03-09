using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace MinhaApi.Tests
{
    public class UtilsTests
    {
        [Fact]
        public void GetFormatJson_SerializesString()
        {
            var utils = new MinhaApi.Utils();
            var result = utils.GetFormatJson("abc");
            Assert.IsType<string>(result);
        }

        [Fact]
        public async Task GetJson_ReturnsContent_WhenFileExists()
        {
            var utils = new MinhaApi.Utils();
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dir);
            var file = Path.Combine(dir, "temp_test.json");
            await File.WriteAllTextAsync(file, "{\"ok\":true}");
            try
            {
                var content = await utils.GetJson("temp_test.json");
                Assert.Equal("{\"ok\":true}", content);
            }
            finally
            {
                File.Delete(file);
            }
        }
    }
}
