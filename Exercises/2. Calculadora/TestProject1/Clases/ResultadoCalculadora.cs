using System;

namespace TestProject1.Clases
{
    public interface IOperando
    {
    }

    public class Entero : IOperando
    {
        public int Valor { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return true;
            Entero other = obj as Entero;
            if (other != null)
            {
                return Valor == other.Valor;
            }
            else
            {
                throw new Exception();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class Decimal : IOperando
    {
        public decimal Valor { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return true;
            Decimal other = obj as Decimal;
            if (other != null)
            {
                return Valor == other.Valor;
            }
            else
            {
                throw new Exception();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class Imaginario : IOperando
    {
        public decimal Real { get; set; }
        public decimal Imag { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return true;
            Imaginario other = obj as Imaginario;
            if (other != null)
            {
                return Real == other.Real && Imag == other.Imag
            }
            else
            {
                throw new Exception();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum EnumStatus
    {
        OK = 0,
        DIVISIONPORCERO = 1,
        DESBORDAMIENTO = 2
    }

    public class ResultadoCalculadora<T> where T : IOperando
    {
        public EnumStatus status { get; set; }
        public T Resultado { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return true;

            ResultadoCalculadora<T> other = obj as ResultadoCalculadora<T>; // realizar casteo del objeto a comparar
            if (other != null)
            {
                if (this.Resultado.Equals(other.Resultado) && this.status == other.status) return true; else return false;
            }
            else
            {
                throw new Exception();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}