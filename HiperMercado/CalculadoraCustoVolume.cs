namespace HiperMercado
{
    public class CalculadoraCustoVolume : ICalculadoraCusto
    {
        public double CalcularCusto(Item item)
        {
            if(item.EhVolume && item.Volume.HasValue && item.CustoPorVolume.HasValue)
            {
                return item.Custo + item.Volume.Value * item.CustoPorVolume.Value;
            }
            return item.Custo;
        }
    }
}
