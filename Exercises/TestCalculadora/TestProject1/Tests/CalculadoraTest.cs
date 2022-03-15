using Moq;
using NUnit.Framework;
using System;
using TestProject1.Clases;
using TestProject1.Interfaces;

namespace TestProject1
{
    public class CalculadoraTest
    {
        private Mock<ICalculadora> _calc;
        [SetUp]
        public void Setup()
        {
            _calc = new Mock<ICalculadora>(MockBehavior.Strict);
        }
        [Test]
        public void SumaPositivoNegativo()
        {
            var operando1 = new Entero { Valor = -10 };
            var operando2 = new Entero { Valor = 10 };
            var result = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = 0 } };

            var result2 = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = 0 } };
            _calc.Setup(x => x.Suma(operando1, operando2)).Returns(result);

            Assert.AreEqual(result2, _calc.Object.Suma(operando1, operando2));
        }

        [Test]
        public void SumaOverflow()
        {
            var operando1 = new Entero { Valor = int.MaxValue };
            var operando2 = new Entero { Valor = 1 };
       
            var result = new ResultadoCalculadora<IOperando> { Resultado=new Entero { Valor=0}, status = EnumStatus.DESBORDAMIENTO };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            // _calc.Setup(x => x.Suma(operando1, operando2)).Throws(new OverflowException());
            _calc.Setup(x => x.Suma(operando1, operando2)).Returns(result);
            //Assert.Throws(typeof(OverflowException), () => _calc.Object.Suma(operando1, operando2));
            Assert.AreEqual(result2, _calc.Object.Suma(operando1, operando2));
        }

        [Test]
        public void SumaDecimales()
        {
            var operando1 = new Clases.Decimal { Valor = 13.4M };
            var operando2 = new Clases.Decimal { Valor = 14.5M };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 27.9M }, status = EnumStatus.OK };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 27.9M }, status = EnumStatus.OK };
            _calc.Setup(x => x.Suma(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Suma(operando1, operando2));
        }

        [Test]
        public void RestaPositivoNegativo()
        {
            var operando1 = new Entero { Valor = -10 };
            var operando2 = new Entero { Valor = 10 };
            var result = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = -20 } };

            var result2 = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = -20 } };
            _calc.Setup(x => x.Resta(operando1, operando2)).Returns(result);

            Assert.AreEqual(result2, _calc.Object.Resta(operando1, operando2));
        }

        [Test]
        public void RestaOverflow()
        {
            var operando1 = new Entero { Valor = int.MinValue };
            var operando2 = new Entero { Valor = 1 };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            _calc.Setup(x => x.Resta(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Resta(operando1, operando2));
        }

        [Test]
        public void RestaDecimales()
        {
            var operando1 = new Clases.Decimal { Valor = 14.4M };
            var operando2 = new Clases.Decimal { Valor = 15.5M };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 1.1M }, status = EnumStatus.OK };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 1.1M }, status = EnumStatus.OK };
            _calc.Setup(x => x.Resta(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Resta(operando1, operando2));
        }
    }
}
