using System;
using Xunit;

namespace xUnitBasics
{
    public class SumDoubleTest
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
        public void Sum_100_1And0_1_ShouldBe100()
        {
            var sum = Sum(100.1, 0.1);
            Assert.Equal(100.2, sum);
        }

        [Fact]
        public void Sum_100_1And0_1_ShouldBe100W4DigitsPrecission()
        {
            var sum = Sum(100.1, 0.1);
            Assert.Equal(100.2, sum, precision: 4);
        }

        private static double Sum(double a, double b)
        {
            return a + b;
        }
    }
}
