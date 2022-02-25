using System;
using Xunit;

namespace xUnitBasics
{
    public class DivideTest
    {
        [Fact]
        public void Divide_8By2_ShouldBe4()
        {
            Assert.Equal(4, Divide(8, 2));
        }

        [Fact(Skip = "Same range of values, not needed")]
        public void Divide_5By2_ShouldBe2()
        {
            Assert.Equal(2, Divide(5, 2));
        }   

        [Fact]
        [Trait("Category", "Exception")]
        [Trait("Category", "Esto se añadió porque....")]
        [Feature("6242")]
        public void Divide_5By0_ShouldThrowDivideBy0Exception()
        {
            Assert.Throws<DivideByZeroException>(
                () => Divide(5, 0)
            );
        }
        private static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
