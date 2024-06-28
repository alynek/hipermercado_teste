using HiperMercado;
using HiperMercado.TiposDeItems;

Item itemRefrigeracao = new ItemRefrigeracao(custo: 50.0, validade: 30, custoRefrigeracao: 10.0);
Item itemVolume = new ItemVolume(custo: 100.0, validade: 10, volume: 5.0, custoPorVolume: 2.0);

var calculadoraDePreco = new CalculadoraPrecoItem();

var precoItemRefrigeracao = calculadoraDePreco.CalcularPreco(itemRefrigeracao);
var precoItemVolume = calculadoraDePreco.CalcularPreco(itemVolume);

Console.WriteLine($"Preço item refrigerado: {precoItemRefrigeracao}");
Console.WriteLine($"Preço item com volume: {precoItemVolume}");