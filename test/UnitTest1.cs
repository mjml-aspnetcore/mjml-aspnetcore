using System.Threading.Tasks;
using mjml.aspnetcore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var services = new ServiceCollection();

            services.AddMjmlServices();

            var provider = services.BuildServiceProvider();

            var mjml = provider.GetRequiredService<IMjmlServices>();

            var result = await mjml.Render("<mjml><mj-body></mj-body></mjml>");
            Assert.IsFalse(result.Errors?.Length > 0);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Html));
        }
    }
}
