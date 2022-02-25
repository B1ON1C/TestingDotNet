using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitAdvanced.Attributes;

namespace xUnitAdvanced
{
    [Collection("DB")]
    public class FullLifecycleTest : IAsyncLifetime
    {
        public FullLifecycleTest()
        {
            var a = 0;
        }

        public async Task DisposeAsync()
        {
            var a = 0;
        }

        public async Task InitializeAsync()
        {
            await Task.Delay(10000);
        }

        [Fact]
        [TestBeforeAfter]
        public void Nop_Nop_ShouldBeTrue()
        {
            Assert.True(true);
        }
    }
}
