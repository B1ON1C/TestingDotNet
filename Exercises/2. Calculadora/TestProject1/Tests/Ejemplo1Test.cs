using Moq;
using NUnit.Framework;
using TestProject1.Interfaces;

namespace TestProject1
{
    public class Ejemplo1Test
    {
        private Mock<IEjemplo1> _ejemplo1;

        [SetUp]
        public void Setup()
        {
            _ejemplo1 = new Mock<IEjemplo1>(MockBehavior.Strict);
            _ejemplo1.Setup(x => x.InvertirNumero("20")).Returns("02");
            _ejemplo1.Setup(x => x.InvertirNumero("a")).Returns("error");
            _ejemplo1.Setup(x => x.InvertirNumero("")).Returns("error");
            _ejemplo1.Setup(x => x.InvertirNumero("4.5")).Returns("error");
            _ejemplo1.Setup(x => x.InvertirNumero("-7")).Returns("error");
            _ejemplo1.Setup(x => x.InvertirNumero("5,15,30")).Returns("error");
        }

        [Test]
        public void NumeroInvertidoCorrecto()
        {
            Assert.AreEqual("02", _ejemplo1.Object.InvertirNumero("20"));
        }

        [Test]
        public void ErrorSiString()
        {
            Assert.AreEqual("error", _ejemplo1.Object.InvertirNumero("a"));
        }

        [Test]
        public void ErrorSiVacio()
        {
            Assert.AreEqual("error", _ejemplo1.Object.InvertirNumero(""));
        }

        [Test]
        public void ErrorSiNoEntero()
        {
            Assert.AreEqual("error", _ejemplo1.Object.InvertirNumero("4.5"));
        }

        [Test]
        public void ErrorSiNoPOsitivo()
        {
            Assert.AreEqual("error", _ejemplo1.Object.InvertirNumero("-7"));
        }

        [Test]
        public void ErrorSiVariosNumeros()
        {
            Assert.AreEqual("error", _ejemplo1.Object.InvertirNumero("5,15,30"));
        }
    }
}