namespace HiperMercado
{
    public class CalcularCustoComum : ICalculadoraCusto
    {
        public double CalcularCusto(Item item)
        {
            return item.Custo;
        }
    }
}
