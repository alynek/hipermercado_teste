
using HiperMercado;

Item itemComum = new Item(20.0, 20);
double precoItemComum = CalculadoraPreco.CalcularPrecoPelaFormulaMagica(itemComum);

Console.WriteLine($"Preço item comum: {precoItemComum}");
