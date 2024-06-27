namespace HiperMercado
{
    public class FabricaDeCalculoCusto
    {
        public static ICalculadoraCusto CriarCalculoCusto(Item item)
        {

            if (item.EhRefrigeracao)
            {
                return new CalculadoraCustoRefrigeracao();
            }

            else if (item.EhVolume)
            {
                return new CalculadoraCustoVolume();
            }
            else
            {
                return new CalcularCustoComum();
            }
        }
    }
}
