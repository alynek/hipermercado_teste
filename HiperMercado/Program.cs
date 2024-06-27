
using HiperMercado;

//Item itemComum = new Item(20.0, 20);
//double precoItemComum = CalculadoraPreco.CalcularPrecoPelaFormulaMagica(itemComum);

//Console.WriteLine($"Preço item comum: {precoItemComum}");



Item itemRefrigeracao = new Item(50.0, 30, necessitaRefrigeracao: true, custoRefrigeracao: 10.0);
Item itemVolume = new Item(100.0, 10, volumoso: true, volume: 5.0, custoPorVolume: 2.0);
Item itemComum = new Item(20.0, 20);

var calculadoraDePreco = new CalculadoraPreco();
var precoItemRefrigeracao = calculadoraDePreco.CalcularPreco(itemRefrigeracao);
var precoItemVolume = calculadoraDePreco.CalcularPreco(itemVolume);
var precoItemComum = calculadoraDePreco.CalcularPreco(itemComum);

Console.WriteLine($"Preço item refrigerado: {precoItemRefrigeracao}");
Console.WriteLine($"Preço item com volume: {precoItemVolume}");
Console.WriteLine($"Preço item comum: {precoItemComum}");