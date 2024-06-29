namespace TestesDeUnidade
{
    public class ProcessaAlgoritmoTestes
    {
        private readonly Rua Rua_Da_Seda;
        private readonly Rua Rua_Da_Seda2;
        private readonly Rua Rua_Do_Aco;
        private readonly Rua Rua_Da_Farinha;
        private readonly Rua Rua_Porto_Real;

        public ProcessaAlgoritmoTestes()
        {
            Rua_Da_Seda = new Rua { Cep = "12345-678", Nome = "Rua da Seda" };
            Rua_Da_Seda2 = new Rua { Cep = "19187-123", Nome = "Rua da Seda" };
            Rua_Do_Aco = new Rua { Cep = "987654-321", Nome = "Rua do Aço" };
            Rua_Da_Farinha = new Rua { Cep = "11111-212", Nome = "Rua da Farinha" };
            Rua_Porto_Real = new Rua { Cep = "99999-111", Nome = "Rua Porto Real" };
        }

        [Theory]
        [MemberData(nameof(ObterCasasComPortoRealPrimeiroLugar))]
        [MemberData(nameof(ObterCasasComRuaDoAcoPrimeiroLugar))]
        public void RetornaAsRuasOrdenadasPelaQuantidadeDeEleitores_Deve_RetornarRuasOrdenadas_Quando_QuantidadEleitoresForMaior(List<Casa> casas, List<Rua> esperado)
        {
            var resultado = ProcessaAlgoritmo.RetornaAsRuasOrdenadasPelaQuantidadeDeEleitores(casas);

            Assert.Equal(esperado, resultado);
        }
        public static IEnumerable<object[]> ObterCasasComPortoRealPrimeiroLugar()
        {
            var testes = new ProcessaAlgoritmoTestes();

            return new List<object[]>
            {
                new object[]
                {
                    new List<Casa>
                    {
                        new Casa { Rua = testes.Rua_Da_Seda, Numero = 5, TotalEleitores = 100 },
                        new Casa { Rua = testes.Rua_Da_Seda, Numero = 2, TotalEleitores = 150 },
                        new Casa { Rua = testes.Rua_Do_Aco, Numero = 1, TotalEleitores = 200 },
                        new Casa { Rua = testes.Rua_Da_Farinha, Numero = 2, TotalEleitores = 50 },
                        new Casa { Rua = testes.Rua_Da_Farinha, Numero = 3, TotalEleitores = 75 },
                        new Casa { Rua = testes.Rua_Porto_Real, Numero = 3, TotalEleitores = 500 }
                    },
                    new List<Rua>
                    {
                        testes.Rua_Porto_Real,
                        testes.Rua_Da_Seda,
                        testes.Rua_Do_Aco,
                        testes.Rua_Da_Farinha
                    }
                }
            };
        }

        public static IEnumerable<object[]> ObterCasasComRuaDoAcoPrimeiroLugar()
        {
            var testes = new ProcessaAlgoritmoTestes();

            return new List<object[]>
            {
                new object[]
                {
                    new List<Casa>
                    {
                        new Casa { Rua = testes.Rua_Da_Seda, Numero = 5, TotalEleitores = 1 },
                        new Casa { Rua = testes.Rua_Da_Seda2, Numero = 5, TotalEleitores = 1 },
                        new Casa { Rua = testes.Rua_Do_Aco, Numero = 1, TotalEleitores = 2 },
                        new Casa { Rua = testes.Rua_Porto_Real, Numero = 3, TotalEleitores = 0 },
                        new Casa { Rua = testes.Rua_Da_Farinha, Numero = 3, TotalEleitores = 0 } 
                    },
                    new List<Rua>
                    {
                        testes.Rua_Do_Aco,
                        testes.Rua_Da_Seda,
                        testes.Rua_Da_Seda2,
                        testes.Rua_Da_Farinha,
                        testes.Rua_Porto_Real
                    }
                }
            };
        }

    }
}