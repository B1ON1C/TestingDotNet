using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Interfaces;

namespace TestProject1
{
    public class Ejemplo2Test
    {
        private Mock<IEjemplo2> _ejemplo2;
        [SetUp]
        public void Setup()
        {

            _ejemplo2 = new Mock<IEjemplo2>(MockBehavior.Default);

            //TODO: probar a montar con expresiones regulares
            _ejemplo2.Setup(x=>x.EsHoraCorrecta(It.IsRegex(@"^(0[0-9]|1[0-9]|2[0-3]),[0-5][0-9]$"))).Returns(true);
            
            /*
            _ejemplo2.Setup(x => x.EsHoraCorrecta("14,05")).Returns(true);
            _ejemplo2.Setup(x => x.EsHoraCorrecta(",45")).Returns(false);
            _ejemplo2.Setup(x => x.EsHoraCorrecta("h,30")).Returns(false);
            _ejemplo2.Setup(x => x.EsHoraCorrecta("15,mm")).Returns(false);
            _ejemplo2.Setup(x => x.EsHoraCorrecta("12,-45")).Returns(false);
            _ejemplo2.Setup(x => x.EsHoraCorrecta("-2,45")).Returns(false);
            _ejemplo2.Setup(x => x.EsHoraCorrecta("2,-45")).Returns(false);
            _ejemplo2.Setup(x => x.EsHoraCorrecta("24,45")).Returns(false);
            _ejemplo2.Setup(x => x.EsHoraCorrecta("3,61")).Returns(false);
            */
        }

        [Test]
        public void HoraCorrectaCorrecto()
        {
            Assert.True(_ejemplo2.Object.EsHoraCorrecta("23,05"));
        }
        [Test]
        public void ErrorSiNoDosParametros()
        {
            Assert.False(_ejemplo2.Object.EsHoraCorrecta(",45"));
        }
        [Test]
        public void ErrorSiPrimerParametroNoNumerico()
        {
            Assert.False(_ejemplo2.Object.EsHoraCorrecta("h,30"));
        }
        [Test]
        public void ErrorSiSegundoParametroNoNumerico()
        {
            Assert.False(_ejemplo2.Object.EsHoraCorrecta("15,mm"));
        }
        [Test]
        public void ErrorSiHoraNegativa()
        {
            Assert.False(_ejemplo2.Object.EsHoraCorrecta("-2,45"));
        }
        [Test]
        public void ErrorSiMinutoNegativo()
        {
            Assert.False(_ejemplo2.Object.EsHoraCorrecta("2,-45"));
        }
        [Test]
        public void ErrorSiHoraMayor23()
        {
            Assert.False(_ejemplo2.Object.EsHoraCorrecta("24,45"));
        }
        [Test]
        public void ErrorSiMinutoMayor60()
        {
            Assert.False(_ejemplo2.Object.EsHoraCorrecta("3,61"));
        }
    }
}
