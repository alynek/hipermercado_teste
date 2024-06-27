using HiperMercado.TiposDeCalculos.Interface;

namespace HiperMercado
{
    public class CalculoCustoComum : ICalculadoraCusto
    {
        public double CalcularCusto(Item item)
        {
            return item.Custo;
        }
    }
}
