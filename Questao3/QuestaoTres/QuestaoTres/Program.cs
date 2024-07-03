//Uma casa sempre será única (número + quantiade de eleitores) em uma rua, por isso o hashset

var casasDaRuaDaSeda = new HashSet<Casa>
{
    new() { Numero = 5, TotalEleitores = 100 },
    new() { Numero = 2, TotalEleitores = 150 },
    new() { Numero = 20, TotalEleitores = 150 },
    new() { Numero = 1, TotalEleitores = 200 },
    new() { Numero = 2, TotalEleitores = 50 },
    new() { Numero = 3, TotalEleitores = 75 },
    new() { Numero = 3, TotalEleitores = 500 }
};

var casasDaRuaDoAco = new HashSet<Casa>
{
    new() { Numero = 5, TotalEleitores = 2 },
    new() { Numero = 2, TotalEleitores = 3 },
    new() { Numero = 20, TotalEleitores = 1 },
};

var casasDaRuaDaFarinha = new HashSet<Casa>
{
    new() { Numero = 5, TotalEleitores = 6 },
    new() { Numero = 2, TotalEleitores = 4 },
    new() { Numero = 20, TotalEleitores = 4 },
};

var ruaDaSeda = new Rua("12345-678", "Rua da seda", casasDaRuaDaSeda);
var ruaDoAco = new Rua("987654-321", "Rua do Aço", casasDaRuaDoAco);
var ruaDaFarinha = new Rua("11111-212", "Rua da Farinha", casasDaRuaDaFarinha);


ruaDaSeda.AdicionarCasa(new Casa() { Numero = 105, TotalEleitores = 20 });
ruaDaSeda.AdicionarMuitasCasas(new HashSet<Casa>
{
    new() { Numero = 5, TotalEleitores = 2 },
    new() { Numero = 2, TotalEleitores = 3 },
    new() { Numero = 20, TotalEleitores = 1 },
});

var listaDeRuas = new List<Rua>() { ruaDaSeda, ruaDoAco, ruaDaFarinha };

foreach (var item in listaDeRuas)
{
    Console.WriteLine($"Nome da rua: {item.Nome}, quantidade ded eleitores: {item.QuantidadeEleitoresRuas}");
}

public class Casa
{
    public int Numero { get; set; }
    public int TotalEleitores { get; set; }
}

public class Rua
{
    public string Cep { get; set; }
    public string Nome { get; set; }

    private HashSet<Casa> Casas { get; set; }

    public int QuantidadeEleitoresRuas { get; private set; }

    public Rua(string cep, string nome, HashSet<Casa> casas)
    {
        Cep = cep;
        Nome = nome;
        Casas = casas;
        QuantidadeEleitoresRuas = casas.Select(_ => _.TotalEleitores).Sum();
    }

    public void AdicionarCasa(Casa casa)
    {
        Casas.Add(casa);
        QuantidadeEleitoresRuas += casa.TotalEleitores;
    }

    public void AdicionarMuitasCasas(HashSet<Casa> casas)
    {
        foreach (var item in casas)
        {
            Casas.Add(item);
            QuantidadeEleitoresRuas += item.TotalEleitores;
        }
    }

    public override bool Equals(object obj)
    {
        return obj is Rua rua && Cep == rua.Cep && Nome == rua.Nome;
    }

    public override int GetHashCode()
    {
        return Cep.GetHashCode() + Nome.GetHashCode();
    }
}



