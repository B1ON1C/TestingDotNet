using TestProject1.Clases;

namespace TestProject1.Interfaces
{
    public interface ICalculadora
    {
        ResultadoCalculadora<IOperando> Suma(IOperando Operando1, IOperando Operando2);

        ResultadoCalculadora<IOperando> Resta(IOperando Operando1, IOperando Operando2);

        ResultadoCalculadora<IOperando> Multiplica(IOperando Operando1, IOperando Operando2);

        ResultadoCalculadora<IOperando> Divide(IOperando Operando1, IOperando Operando2);

        ResultadoCalculadora<IOperando> Raiz(IOperando Operando1);

        ResultadoCalculadora<IOperando> Cuadrado(IOperando Operando1);

        ResultadoCalculadora<IOperando> Potencia(IOperando Operando1, IOperando Operando2);
    }
}