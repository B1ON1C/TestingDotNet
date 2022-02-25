using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitAdvanced
{
    public class DemoTests : IAsyncLifetime
    {
        public async Task DisposeAsync()
        {
            
        }

        public async Task InitializeAsync()
        {
           
        }

        public void Whatever() { }
    }
}
