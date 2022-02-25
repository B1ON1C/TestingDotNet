using Xunit;

namespace xUnitBasics
{
    public class UnitTest1
    {
        [Fact]
        public void TestAlwaysTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void TestAlwaysFalse()
        {
            Assert.False(false);
        }

        [Fact]
        public void TestStringStartingWithHelloWorld()
        {
            var welcomeString =
                "Hello World! This is my first functional test :-]";
            var result = welcomeString.StartsWith("Hello World!");
            Assert.True(result);
        }


        [Fact]
        public void TestStringLimit50Char()
        {
            var welcomeString =
                "Hello World! This is my first functional test :-]            ";
            var result = welcomeString.Trim().Length < 50;
            Assert.True(result);
        }
    }
}
