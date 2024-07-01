/*
 Um candidato a prefeito quer saber quais ruas ele deve visitar para impactar o maior
número de eleitores. Abaixo seguem objetos já existentes que representam casas e ruas:
 */

var ruaDaSeda = new Rua { Cep = "12345-678", Nome = "Rua da seda" };
var ruaDoAco = new Rua { Cep = "987654-321", Nome = "Rua do Aço" };
var ruaDaFarinha = new Rua { Cep = "11111-212", Nome = "Rua da Farinha" };
var ruaPortoReal = new Rua { Cep = "99999-111", Nome = "Rua Porto Real" };

var casas = new List<Casa>
{
    new() { Rua = ruaDaSeda, Numero = 5, TotalEleitores = 100 },
    new() { Rua = ruaDaSeda, Numero = 2, TotalEleitores = 150 },
    new() { Rua = ruaDoAco, Numero = 1, TotalEleitores = 200 },
    new() { Rua = ruaDaFarinha, Numero = 2, TotalEleitores = 50 },
    new() { Rua = ruaDaFarinha, Numero = 3, TotalEleitores = 75 },
    new() { Rua = ruaPortoReal, Numero = 3, TotalEleitores = 500 }
};

var resultado = ProcessaAlgoritmo.RetornaAsRuasOrdenadasPelaQuantidadeDeEleitores(casas);

resultado.ForEach(_ => Console.WriteLine($"Rua: {_.Nome}"));

public static class ProcessaAlgoritmo
{
    public static List<Rua> RetornaAsRuasOrdenadasPelaQuantidadeDeEleitores(List<Casa> casas)
    {
        var quantidadeEleitoresRuas = new Dictionary<Rua, int>();

        casas.ForEach(_ =>
        {
            if (quantidadeEleitoresRuas.ContainsKey(_.Rua))
            {
                quantidadeEleitoresRuas[_.Rua] += _.TotalEleitores;
            }
            else
            {
                quantidadeEleitoresRuas[_.Rua] = _.TotalEleitores;
            }
        });

        var ruasOrdenadasPelosEleitores = quantidadeEleitoresRuas
           .OrderByDescending(chave => chave.Value)
           .ThenBy(chave => chave.Key.Nome)
           .Select(chave => chave.Key)
           .ToList();

        return ruasOrdenadasPelosEleitores;
    }
}


public class Casa { 
    public Rua Rua { get; set; }
    public int Numero { get; set; }
    public int TotalEleitores { get; set; }
}

public class Rua
{
    public string Cep { get; set; }
    public string Nome { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Rua rua && Cep == rua.Cep && Nome == rua.Nome;
    }

    public override int GetHashCode()
    {
        return Cep.GetHashCode() + Nome.GetHashCode();
    }
}



