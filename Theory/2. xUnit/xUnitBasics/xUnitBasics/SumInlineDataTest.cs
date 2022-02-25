using System;
using Xunit;

namespace xUnitBasics
{
    public class SumInlineDataTest
    {
        [Theory]
        [InlineData(5, 2, 3)]
        [InlineData(18, 12, 6)]
        [InlineData(1, -2, 3)]
        [InlineData(-5, -2, -3)]
        [InlineData(int.MinValue,
            int.MaxValue, 1)]
        [InlineData(int.MaxValue,
            int.MinValue, -1)]
        public void Sum_TupleValues_ShouldBeCorrect(
            int expected, int a, int b)
        {
            Assert.Equal(expected, Sum(a, b));
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
