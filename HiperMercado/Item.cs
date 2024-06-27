namespace HiperMercado
{
    public class Item
    {
        public double Custo { get; set; }
        public int Validade { get; set; }

        public Item(double custo, int validade)
        {
            Custo = custo;
            Validade = validade;
        }
    }
}
