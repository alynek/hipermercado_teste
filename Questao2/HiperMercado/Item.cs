namespace HiperMercado
{
    public class Item
    {
        public double Custo { get; set; }
        public int Validade { get; set; }
        public double? CustoRefrigeracao { get; set; }
        public double? Volume { get; set; }
        public double? CustoPorVolume { get; set; }
        public bool EhRefrigeracao { get; set; }
        public bool EhVolume { get; set; }

        public Item(double custo, int validade, bool ehRefrigeracao = false, double? custoRefrigeracao = null,
            bool ehVolume = false, double? volume = null, double? custoPorVolume = null)
        {
            Custo = AumentaCusto(custo, validade);
            Validade = validade;
            EhRefrigeracao = ehRefrigeracao;
            CustoRefrigeracao = custoRefrigeracao;
            EhVolume = ehVolume;
            Volume = volume;
            CustoPorVolume = custoPorVolume;
        }

        public double AumentaCusto(double custo, int validade)
        {
            if (EstaProximoDoVencimento(validade))
            {
                return 2 * custo;
            }
            return custo;
        }

        public bool EstaProximoDoVencimento(int validade)
        {
            var dataAtual = DateTime.Now;
            dataAtual = dataAtual.AddDays(validade);
            var dataDaquiUmMes = DateTime.Now.AddMonths(1);

            return dataAtual < dataDaquiUmMes;
        }
    }
}
