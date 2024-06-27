using HiperMercado.TiposDeCalculos.Interface;

namespace HiperMercado.TiposDeCalculos
{
    public class CalculoCustoRefrigeracao : ICalculadoraCusto
    {
        public double CalcularCusto(Item item)
        {
            if (item.EhRefrigeracao && item.CustoRefrigeracao.HasValue)
            {
                return item.Custo + item.CustoRefrigeracao.Value;
            }
            return item.Custo;
        }
    }
}
