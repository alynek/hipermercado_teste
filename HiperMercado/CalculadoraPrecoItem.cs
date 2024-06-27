using HiperMercado.HiperMercadoLib;
using HiperMercado.TiposDeCalculos;

namespace HiperMercado
{
    public class CalculadoraPrecoItem
    {
        public double CalcularPreco(Item item)
        {
            var tipoDeCalculoCusto = FabricaDeCalculoCusto.CriarCalculoCusto(item);
            var custoTotal = tipoDeCalculoCusto.CalcularCusto(item);

            double preco = Hi.formulaMagica(custoTotal, item.Validade);
            return preco;
        }
    }
}
