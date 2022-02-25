using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitAdvanced
{
    public class XUnitInstanceTest
    {
        private int a = 0;

        [Fact]
        public void Test1()
        {
            a++;
            Assert.Equal(1, a);
        }

        [Fact]
        public void Test2()
        {
            a++;
            Assert.Equal(1, a);
        }
    }
}
