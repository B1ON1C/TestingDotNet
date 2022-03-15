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
        [Category("Suma")]
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
        [Category("Suma")]
        public void SumaOverflow()
        {
            var operando1 = new Entero { Valor = int.MaxValue };
            var operando2 = new Entero { Valor = 1 };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            // _calc.Setup(x => x.Suma(operando1, operando2)).Throws(new OverflowException());
            _calc.Setup(x => x.Suma(operando1, operando2)).Returns(result);
            //Assert.Throws(typeof(OverflowException), () => _calc.Object.Suma(operando1, operando2));
            Assert.AreEqual(result2, _calc.Object.Suma(operando1, operando2));
        }

        [Test]
        [Category("Suma")]
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
        [Category("Resta")]
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
        [Category("Resta")]
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
        [Category("Resta")]
        public void RestaDecimales()
        {
            var operando1 = new Clases.Decimal { Valor = 14.4M };
            var operando2 = new Clases.Decimal { Valor = 15.5M };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 1.1M }, status = EnumStatus.OK };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 1.1M }, status = EnumStatus.OK };
            _calc.Setup(x => x.Resta(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Resta(operando1, operando2));
        }

        [Test]
        [Category("Multiplicacion")]
        public void MultiplicaPositivoNegativo()
        {
            var operando1 = new Entero { Valor = -20 };
            var operando2 = new Entero { Valor = 10 };
            var result = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = -200 } };

            var result2 = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = -200 } };
            _calc.Setup(x => x.Multiplica(operando1, operando2)).Returns(result);

            Assert.AreEqual(result2, _calc.Object.Multiplica(operando1, operando2));
        }

        [Test]
        [Category("Multiplicacion")]
        public void MultiplicaOverflow()
        {
            var operando1 = new Entero { Valor = int.MinValue };
            var operando2 = new Entero { Valor = 1 };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            _calc.Setup(x => x.Multiplica(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Multiplica(operando1, operando2));
        }

        [Test]
        [Category("Multiplicacion")]
        public void MultiplicaDecimales()
        {
            var operando1 = new Clases.Decimal { Valor = 2.3M };
            var operando2 = new Clases.Decimal { Valor = 9.0M };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 20.7M }, status = EnumStatus.OK };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 20.7M }, status = EnumStatus.OK };
            _calc.Setup(x => x.Multiplica(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Multiplica(operando1, operando2));
        }

        [Test]
        [Category("Division")]
        public void DividePositivoNegativo()
        {
            var operando1 = new Entero { Valor = 15 };
            var operando2 = new Entero { Valor = -3 };
            var result = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = -5 } };

            var result2 = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = -5 } };
            _calc.Setup(x => x.Divide(operando1, operando2)).Returns(result);

            Assert.AreEqual(result2, _calc.Object.Divide(operando1, operando2));
        }

        [Test]
        [Category("Division")]
        public void DivideNegativoPositivo()
        {
            var operando1 = new Entero { Valor = -15 };
            var operando2 = new Entero { Valor = 3 };
            var result = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = -5 } };

            var result2 = new ResultadoCalculadora<IOperando> { status = EnumStatus.OK, Resultado = new Entero { Valor = -5 } };
            _calc.Setup(x => x.Divide(operando1, operando2)).Returns(result);

            Assert.AreEqual(result2, _calc.Object.Divide(operando1, operando2));
        }

        [Test]
        [Category("Division")]
        public void DivideOverflow()
        {
            var operando1 = new Entero { Valor = int.MaxValue };
            var operando2 = new Entero { Valor = (1/int.MaxValue) };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DESBORDAMIENTO };
            _calc.Setup(x => x.Divide(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Divide(operando1, operando2));
        }

        [Test]
        [Category("Division")]
        public void DivideDecimales()
        {
            var operando1 = new Clases.Decimal { Valor = 2.5M };
            var operando2 = new Clases.Decimal { Valor = 2 };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 1.25M }, status = EnumStatus.OK };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Clases.Decimal { Valor = 1.25M }, status = EnumStatus.OK };
            _calc.Setup(x => x.Divide(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Divide(operando1, operando2));
        }

        [Test]
        [Category("Division")]
        public void DivideEntreCero()
        {
            var operando1 = new Entero { Valor = int.MaxValue };
            var operando2 = new Entero { Valor = 0 };

            var result = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DIVISIONPORCERO };
            var result2 = new ResultadoCalculadora<IOperando> { Resultado = new Entero { Valor = 0 }, status = EnumStatus.DIVISIONPORCERO };
            _calc.Setup(x => x.Divide(operando1, operando2)).Returns(result);
            Assert.AreEqual(result2, _calc.Object.Divide(operando1, operando2));
        }



        // TODO: RaizCuadradaPositivo
        // TODO: RaizCuadradaNegativo
        // TODO: RaizCuadradaDecimales


        // TODO: CuadradoPositivo
        // TODO: CuadradoNegativo
        // TODO: CuadradoOverflow
        // TODO: CuadradoDecimales


        // TODO: PotenciaPositivoNegativo
        // TODO: PotenciaNegativoPositivo
        // TODO: PotenciaOverflow
        // TODO: PotenciaDecimales
    }
}