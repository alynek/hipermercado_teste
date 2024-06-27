using HiperMercado.TiposDeCalculos.Interface;

namespace HiperMercado.TiposDeCalculos
{
    public class FabricaDeCalculoCusto
    {
        public static ICalculadoraCusto CriarCalculoCusto(Item item)
        {

            if (item.EhRefrigeracao)
            {
                return new CalculoCustoRefrigeracao();
            }

            else if (item.EhVolume)
            {
                return new CalculoCustoVolume();
            }
            else
            {
                return new CalculoCustoComum();
            }
        }
    }
}
