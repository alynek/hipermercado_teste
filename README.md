# Executando o projeto
Para executar o projeto é preciso ter o .NET 8.0 (versão SDK 8.0.302) instalado na máquina, o mesmo se encontra no link: 
https://dotnet.microsoft.com/pt-br/download/dotnet/8.0

Depois de instalar, basta clonar o projeto ou baixar o zip e abrir com sua IDE ou editor de texto.
As questões estão separadas por pastas, cada questão que exigiu código tem sua própria solution e um projeto com os testes de unidade.

# Questões

### Questão 1) 
**a)** Bom depende, vai depender do que está sendo feito. Porque? 

**Em uma interface** por exemplo, tem apenas a assinatura dos métodos, não tem a implementação em si,
contudo uma classe que implemente uma interface, pode implementar mais de uma interface (caso precise), 
além disso se precisarmos usar essa classe, podemos chamar a interface onde precisamos, um exemplo clássico 
é em um projeto web, onde temos as services (classes onde geralmente temos as nossas regras de negócio), e
precisamos chamar elas em uma controller, podemos usar uma interface para isso, então no construtor da controller, 
eu uso injeção de dependência, chamando a interface da minha service, isso deixa minha controller desacoplada, pois não 
preciso instanciar uma classe externa nela, melhorando a manutenibilidade, os testes também ficam mais fáceis e sem falar que é 
uma boa prática e deixa a controller com um melhor design (no sentido de refatoração, design de código).

*Exemplo de injeção de dependência em uma Controller:*
```
  public class FinalizaCompraController : ControllerBase
    {
        private readonly ITentativaPagamentoService _tentativaPagamentoService;

        public FinalizaCompraController(ITentativaPagamentoService tentativaPagamentoService)
        {
            _tentativaPagamentoService = tentativaPagamentoService;
        }
   }
```

ou seja, dentro dela preciso chamar apenas o método usando a interface (responsabilidade única, DIP => SOLID).


**Em uma classe abstrata**, eu posso querer usar ela se vejo a necessidade de ter classes filhas que tem métodos comuns, e herdando de uma classe base, o benefício principal é conseguir reutilizar o mesmo código, pois ele pode "viver" na classe mãe e apenas ser chamado nas classes filhas, ou podemos sobrescrever o método, ou até mesmo na classe base termos apenas um método abstrato e as classes filhas implementam o método, com os mesmos parâmetros da classe base.

Exemplo: digamos que eu tenho uma funcionalidade de enviar email's, existem email's que são enviados para diferentes tipos de usuários com base em uma regra, então temos o usuário admin, este recebe um tipo de email com alguns dados informacionais a mais e temos o usuário gerente, este vai receber também um email mas com uma mensagem e alguns dados diferentes.

Apesar da semelhança na lógica, ambas tem mensagens diferentes, então podemos ter na classe abstrata:
public override void EnviarMensagem(Dados dados);
 
E nas duas classes filhas, podemos ter a implementação deste método, que é semelhante para as duas, mas ainda assim dependendo de quem usar, faz algo diferente (Polimorfismo), no caso, passamos mais dados para enviar um email ao usuário admin.

*Exemplo de uma classe base abstrata:*
![classebase](https://github.com/alynek/hipermercado_teste/assets/79387967/b108d013-e66d-49c7-a54d-d4b1fae25af0)


**b)** Nesse caso também é um depende, (muitas decisões em um software sempre vão depender do design do sistema e do propósito dele).

**Sobre usar herança:** se comporta parecido com a classe abstrata da questão anterior, pois quando vemos o benefício de uma classe poder reutilizar um método existente de outra classe, podemos usar herança pra isso, obviamenet temos que estar sempre atentos à dependência que isso gera, pois a classe filha ficará dependente da classe base quando houver uma mudança.

**Sobre usar delegação a outros objetos:** temos novamente os exemplos clássicos do dia a dia, onde em uma controller, podemos ter diversas services, então digamos que temos uma controller pagamentoController, e dentro dela preciso chamar 
a pagamentoService, que conterá a minha lógica e regras de negócios, além disso também posso ter a minha loggerService, que será uma service que pode loggar (guardar) os erros e informações da minha aplicação, eu também posso ter uma emailService, 
que pode ser chamada após a pagamentoService, para enviar um e-mail avisando o usuário do procedimento da transação. 

*Exemplo de uma CarrinhoController:*
![delegacao de objetos](https://github.com/alynek/hipermercado_teste/assets/79387967/186301d9-7cdb-4908-9552-42f785e3d685)

### Questão 2) Link do Github com o código: https://github.com/alynek/hipermercado_teste/tree/branchUsandoClasseBase/Questao2

### Questão 3) Link do Github com o código: https://github.com/alynek/hipermercado_teste/tree/branchUsandoClasseBase/Questao3/QuestaoTres

### Questão 4) 

**a)** Sim, é uma boa prática, pois quando lançamos uma exceção do tipo Exception, no lugar onde vamos olhar (geralmente um sisstema de log de erros), fica mais difícil compreender de fato o problema e ter uma melhor assertividade na tratativa do erro, 
por exemplo, digamos que temos uma aplicação como a mencionada no problema 5, que debita e credita valores em uma conta, seria muito mais interessante termos e lançarmos uma SaldoInsuficienteExceptnio, nessa nossa classe específica poderíamos colocar 
dados controlados ou a mais sobre o erro, considerando esse caso que envolve dados sensíveis.
Além disso, usando uma exception personalizada, podemos adicionar fluxos diferentes no código, exatamente porque temos essa exception não genérica.

**b)** Eu adicionaria esse tipo de tratamento em trechos de código que por exemplo, fazem consulta ou persistência dos dados, pois sempre pode surgir o risco do servidor do banco ficar fora do ar ou estar indisponível, enfim  é uma possibilidade. É muito comum 
também cláusulas try catch quando lidamos com arquivos, como operações de abrir algum arquivo, salvar, etc. Então nesses casos também é importante. Acredito que existem mais cenários também, mas isso vai depender do design do projeto.

**c)** Temos diversos casos de exemplo, em um endpoint de uma api, podemos lançar uma exceção quando ao tentar validar o input recebido, ele estiver null, ou quanod alguns dos dados não forem válidos, nesse caso, podemos loggar o erro e depois lançar 
a exception, no caso podemos ter uma exception mais específica para um erro possível de acontecer, como dado nulo, saldo insuficiente, etc. E também podemos ter uma excecption genérica para algum erro interno no servidor.

*Exemplo validando o input: PagamentoDTO, que tem a possibilidade de vir null do client:*
![image](https://github.com/alynek/hipermercado_teste/assets/79387967/1cb38dc5-a3b7-472f-8d28-58f2bbd63f03)

### Questão 5)
**Sobre concorrência**, analisando os métodos debitar e creditar, ambos não tem nenhum controle de concorrência, isso significa que no caso de um usuário fazer duas operações de uma vez, pode fazer com que os dados fiquem corrompidos, por exemplo: debitar duas vezes o valor de 50 em um saldo de 50, resultando em um saldo negativo.
Ou seja, os dados não estariam íntegros, no .NET por exemplo, temos uma abordagem que é a de de usar “locks”, que seria uma espécie de bloqueio na transação, ou seja, na prática apenas uma thread poderia modificar o dado por vez, por conta da implementação do lock. 
Um exemplo da vida real (vou omitir a maioria dos detalhes específicos e técnicos) que posso comentar como mais um exemplo, foi uma aplicação em .NET, que exibia na tela uma lista de ações, onde essa lista de ações tinham operações básicas de CRUD e outras mais e cada ação tinha um status, além disso em background existia um job (uma rotina), que a cada certa quantidade de tempo, fazia uma busca no banco para obter as ações com status: em andamento, e atualizava elas para o status: atrasado, com base em certas condições, na operação de atualizar uma ação, foi preciso desenvolver um sistema de bloqueio no código, (lock), para garantir que o endpoint update, não concorresse com o job que estava rodando em background.

**Sobre escopo de transações**, este também anda “de mãos dadas” com o exemplo anterior, pois como temos dois processamentos de alteração no banco, um após o outro, (debitar e atualizar) , se um deles falhar, teremos inconsistências nos dados, por exemplo:

linha 1 :  conta.debite(valor); 
linha 2:  contaDao.atualiza(conta);

Na linha 1, estamos fazendo a operação de debitar da conta, isso faz com que o dado no banco já seja alterado, e na linha 2 temos mais uma operação, o problema é que existe a possibilidade de na hora de atualizar os dados, acontecer algum problema (servidor cair, aplicação fora do ar, etc.) e consequentemente os dados não seriam atualizados, causando inconsistência nos dados, e analogamente o método creditar() se comporta de maneira parecida.
Um apossível abordagem no .NET é usar transaction, com isso podemos envoolver a lógica de debitar e atualizar e etc, dentro de uma cláusula TransactionScope, exemplo abaixo:

*Agora os métodos Debite e Atualiza, estão dentro de uma cláusula TransacationScope,onde no final da operação Atualiza, é que de fato completamos a operação*
![transaction](https://github.com/alynek/hipermercado_teste/assets/79387967/7d8345c6-f2c2-406c-91fe-d896e342bac8)

*No entity framework também temos a abordagem de utilizar alguns métodos do próprio framework, abaixo um exempo simples:*
![commit](https://github.com/alynek/hipermercado_teste/assets/79387967/da750462-51ae-48ba-87df-85ba919d52b3)


### Questão 6) Link do Github com as querys de criação, inserção e consulta: https://github.com/alynek/hipermercado_teste/tree/branchUsandoClasseBase/Questao6

Nessa questão, observei que era importante ter uma coluna a mais na consulta que retorna os kits, chamada: QuantidadeMaximaKits, afinal, o que forma um kit é:

1 produto de limpeza que foi bem avaliado + 1 alimento próximo do vencimento

![image](https://github.com/alynek/hipermercado_teste/assets/79387967/b0acaf5c-4e62-4226-989e-38707184408e)

Logo na quantidade máxima de kits que eu posso montar,  deve ser levado em consideração a menor quantiade de um produto que "cria" um kit, por exemplo:

Supondo que eu tenho um total de 
 - 80 quantidades de carne
 - 100 quantidades de detergentes
 - 100 quantidades de sabão em pó

Eu só posso criar as seguintes combinações, porque a menor quantidade de produtos é 80, ou seja, eu não poderia montar 100 kits de detergentes sendo que tenho apenas 80 carnes:
 - Possível kit 1: 80 kits, cada um com: 1 carne +  1 detergente
 - Possível kit 2: 80 kits, cada um com: 1 carne +  1 sabão em pó

 A escolha de cada kit, poderia ser algo como: **20 kit's do tipo 1 + 60 kit's do tipo 2**   
 ou   **1 kit do tipo 1 + 79 kit's do tipo 2**


*Abaixo se encontra o resultado final da query:*

![image](https://github.com/alynek/hipermercado_teste/assets/79387967/a384d1b8-77ba-43ed-910a-42c6317d6f08)



*E aqui estão os dados de etodas as tabelas:*

![image](https://github.com/alynek/hipermercado_teste/assets/79387967/4ace41a2-02c4-4453-9526-3879bbc053f1)



