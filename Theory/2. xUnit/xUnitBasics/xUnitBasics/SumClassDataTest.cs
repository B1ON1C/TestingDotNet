using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitBasics
{
    public class SumClassDataTest
    {
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
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
    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 5, 2, 3 };
            yield return new object[] { 18, 12, 6 };
            yield return new object[] { 1, -2, 3 };
            yield return new object[] { -5, -2, -3 };
            yield return new object[] { int.MinValue, int.MaxValue, 1};
            yield return new object[] { int.MaxValue, int.MinValue, -1 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
