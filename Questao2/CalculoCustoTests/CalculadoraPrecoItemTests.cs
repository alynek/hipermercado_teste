namespace CalculoCustoTests
{
    using HiperMercado;
    using Xunit;

    public class CalculadoraPrecoItemTests
    {
        [Theory]
        [InlineData(50.0, 30, true, 10.0, false, 0, 0, 90.0)] // Item do tipo Refrigeração
        [InlineData(100.0, 10, false, 0, true, 5.0, 2.0, 120.0)] // Item do tipo Volume
        [InlineData(20.0, 20, false, 0, false, 0, 0, 40.0)] // Item Comum
        public void CalcularPreco_ValidaPrecoCorretamente(double custo, int validade, bool ehRefrigeracao, double custoRefrigeracao, 
            bool ehVolume, double volume, double custoPorVolume, double precoEsperado)
        {
            //Arrange
            var item = new Item(custo, validade, ehRefrigeracao, custoRefrigeracao,
                                ehVolume, volume, custoPorVolume);

            var calculadoraDePreco = new CalculadoraPrecoItem();

            // Act
            var precoRetornado = calculadoraDePreco.CalcularPreco(item);

            // Assert
            Assert.Equal(precoEsperado, precoRetornado);
        }
    }
}