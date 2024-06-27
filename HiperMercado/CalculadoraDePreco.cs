namespace HiperMercado
{
    public static class CalculadoraPreco
    {
        public static double CalcularPrecoPelaFormulaMagica(Item item)
        {
            return item.Custo + item.Validade;
        }
    }
}
