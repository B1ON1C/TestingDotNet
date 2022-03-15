using Moq;
using NUnit.Framework;
using TestProject1.Interfaces;

namespace TestProject1
{
    public class Ejemplo3Test
    {
        private Mock<IEjemplo3> _ejemplo3;

        [SetUp]
        public void Setup()
        {
            _ejemplo3 = new Mock<IEjemplo3>(MockBehavior.Strict);
            _ejemplo3.Setup(x => x.BuscarPosicion(-10000, new int[] { 0, -10000, 10000 })).Returns(2);
            _ejemplo3.Setup(x => x.BuscarPosicion(-20000, new int[] { 0, -10000, 10000 })).Returns(-1);
            _ejemplo3.Setup(x => x.BuscarPosicion(-20000, new int[] { })).Returns(-2);
            //_ejemplo3.Setup(x => x.BuscarPosicion(Int32.MaxValue + 1, new int[] { 1 }))Returns(-2); Overflow
        }

        [Test]
        public void BuscarPosicionCorrecto()
        {
            Assert.AreEqual(2, _ejemplo3.Object.BuscarPosicion(-10000, new int[] { 0, -10000, 10000 }));
        }

        [Test]
        public void BuscarPosicionNoEncontradoCorrecto()
        {
            Assert.AreEqual(-1, _ejemplo3.Object.BuscarPosicion(-20000, new int[] { 0, -10000, 10000 }));
        }

        [Test]
        public void ErrorSiVacio()
        {
            Assert.AreEqual(-2, _ejemplo3.Object.BuscarPosicion(-20000, new int[] { }));
        }
    }
}