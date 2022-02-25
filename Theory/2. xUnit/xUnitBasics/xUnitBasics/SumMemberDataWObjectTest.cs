using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitBasics
{
    public class SumMemberDataWObjectTest
    {
        [Theory]
        [MemberData(nameof(CalculatorData.Data), MemberType = typeof(CalculatorData))]
        public void Sum_TupleValues_ShouldBeCorrect(
            int expected, int a, int b)
        {
            Assert.Equal(expected, Sum(a, b));
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }

        public class CalculatorData
        {
            public static IEnumerable<object[]> Data =>
                new List<object[]>
                {
                    new object[] { 5, 2, 3 },
                    new object[] { 18, 12, 6 },
                    new object[] { 1, -2, 3 },
                    new object[] { -5, -2, -3 },
                    new object[] { int.MinValue, int.MaxValue, 1 },
                    new object[] { int.MaxValue, int.MinValue, -1 }
                };
        }
        
    }
    
}
