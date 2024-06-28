using HiperMercado.HiperMercadoLib;
using HiperMercado.TiposDeItems;

namespace HiperMercado
{
    public class CalculadoraPrecoItem
    {
        public double CalcularPreco(Item item)
        {
            var custoTotalItem = item.CalcularCusto();

            double preco = Hi.formulaMagica(custoTotalItem, item.Validade);
            return preco;
        }
    }
}
