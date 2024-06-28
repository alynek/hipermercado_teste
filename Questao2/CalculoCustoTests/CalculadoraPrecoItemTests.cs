namespace CalculoCustoTests
{
    using HiperMercado;
    using Xunit;

    public class CalculadoraPrecoItemTests
    {
        [Theory]
        [InlineData(50.0, 60, true, 10.0, false, 0, 0, 120.0)] // Item do tipo Refrigeração
        [InlineData(100.0, 100, false, 0, true, 5.0, 2.0, 210.0)] // Item do tipo Volume
        [InlineData(20.0, 80, false, 0, false, 0, 0, 100.0)] // Item Comum
        public void CalcularPreco_Deve_RetornarPrecoCorreto_Quando_NaoEstaProximoDoVencimento(double custo, int validade, bool ehRefrigeracao, double custoRefrigeracao, 
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

        [Theory]
        [InlineData(50.0, 2, true, 10.0, false, 0, 0, 112.0)] // Item do tipo Refrigeração
        [InlineData(100.0, 10, false, 0, true, 5.0, 2.0, 220.0)] // Item do tipo Volume
        [InlineData(20.0, 20, false, 0, false, 0, 0, 60.0)] // Item Comum
        public void CalcularPreco_Deve_RetornarPrecoCorreto_Quando_ProximoVencimento(double custo, int validade, bool ehRefrigeracao, double custoRefrigeracao,
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