namespace HiperMercado.TiposDeItems
{
    public class ItemRefrigeracao : Item
    {
        public double CustoRefrigeracao { get; set; }

        public ItemRefrigeracao(double custo, int validade, double custoRefrigeracao)
             : base(custo, validade)
        {
            Custo = custo;
            Validade = validade;
            CustoRefrigeracao = custoRefrigeracao;
        }

        public override double CalcularCusto()
        {
            if (EstaProximoDoVencimento())
            {
                return (2 * Custo) + CustoRefrigeracao;
            }
            return Custo + CustoRefrigeracao;
        }
    }
}
