using System;
using Xunit;

namespace xUnitBasics
{
    public class SumTest
    {

        [Fact]
        public void Sum_2And3_ShouldBe5WBool()
        {
            bool result = Sum(2, 3) == 5;
            Assert.True(result);
        }

        [Fact]
        public void Sum_2And3_ShouldBe5()
        {
            Assert.Equal(5, Sum(2, 3));
        }

        [Fact]
        public void Sum_12And6_ShouldBe18()
        {
            Assert.Equal(18, Sum(12, 6));
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
