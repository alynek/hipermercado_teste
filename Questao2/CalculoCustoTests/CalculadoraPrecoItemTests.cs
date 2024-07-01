namespace CalculoCustoTests
{
    using HiperMercado;
    using HiperMercado.TiposDeItems;
    using Xunit;

    public class CalculadoraPrecoItemTests
    {
        [Fact]
        public void CalcularPreco_Deve_ValidarPrecoCorretamente_Quando_ItemEhRefrigeracao()
        {
            //Arrange
            var item = new ItemRefrigeracao(custo: 50.0, validade: 30, custoRefrigeracao: 10.0);

            var calculadoraDePreco = new CalculadoraPrecoItem();

            // Act
            var precoRetornado = calculadoraDePreco.CalcularPreco(item);
            var precoEsperado = 140;

            // Assert
            Assert.Equal(precoEsperado, precoRetornado);
        }
        
        [Fact]
        public void CalcularPreco_Deve_ValidarPrecoCorretamente_Quando_ItemEhVolume()
        {
            //Arrange
            var item = new ItemVolume(custo: 100.0, validade: 10, volume: 5.0, custoPorVolume: 2.0);

            var calculadoraDePreco = new CalculadoraPrecoItem();

            // Act
            var precoRetornado = calculadoraDePreco.CalcularPreco(item);
            var precoEsperado = 220;

            // Assert
            Assert.Equal(precoEsperado, precoRetornado);
        }
    }
}