namespace HiperMercado.TiposDeItems
{
    public class ItemVolume : Item
    {
        public double Volume { get; set; }
        public double CustoPorVolume { get; set; }

        public ItemVolume(double custo, int validade, double volume, double custoPorVolume)
            : base(custo, validade)
        {
            Custo = custo;
            Validade = validade;
            Volume = volume;
            CustoPorVolume = custoPorVolume;
        }

        public override double CalcularCusto()
        {
            if (EstaProximoDoVencimento())
            {
                return (2 * Custo) + Volume * CustoPorVolume;
            }
            return Custo + Volume * CustoPorVolume;
        }
    }
}
