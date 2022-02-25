using System;
using Xunit;

namespace xUnitBasics
{
    public class SumDecimalTest
    {
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

        [Fact]
        public void Sum_100_1And0_1_ShouldBe100_2()
        {
            var sum = Sum(100.1m, 0.1m);
            Assert.Equal(100.2m, sum);
        }

        private static decimal Sum(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
