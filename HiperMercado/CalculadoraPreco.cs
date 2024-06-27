namespace HiperMercado
{
    public class CalculadoraPreco
    {
        public double CalcularPreco(Item item)
        {
            var tipoDeCalculoCusto = FabricaDeCalculoCusto.CriarCalculoCusto(item);
            var custoTotal = tipoDeCalculoCusto.CalcularCusto(item);

            double preco = HiperMercado.Hi.formulaMagica(custoTotal, item.Validade);
            return preco;
        }
    }
}
