namespace HiperMercado.TiposDeItems
{
    public abstract class Item
    {
        public double Custo { get; set; }
        public int Validade { get; set; }

        public Item(double custo, int validade)
        {
            Custo = custo;
            Validade = validade;
        }

        public abstract double CalcularCusto();

        public bool EstaProximoDoVencimento()
        {
            var dataAtual = DateTime.Now;
            dataAtual = dataAtual.AddDays(Validade);
            var dataDaquiUmMes = DateTime.Now.AddMonths(1);

            return dataAtual < dataDaquiUmMes;
        }
    }
}
