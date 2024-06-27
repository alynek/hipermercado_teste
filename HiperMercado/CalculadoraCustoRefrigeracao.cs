namespace HiperMercado
{
    public class CalculadoraCustoRefrigeracao : ICalculadoraCusto
    {
        public double CalcularCusto(Item item)
        {
            if(item.EhRefrigeracao && item.CustoRefrigeracao.HasValue)
            {
                return item.Custo + item.CustoRefrigeracao.Value;
            }
            return item.Custo;
        }
    }
}
