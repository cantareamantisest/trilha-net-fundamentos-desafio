using DesafioFundamentos.Helpers;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;
bool precoInicialValido = false;
bool precoPorHoraValido = false;
string s_precoInicial = "";
string s_precoPorHora = "";
decimal precoInicial = 0;
decimal precoPorHora = 0;


do 
{  
    Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
    s_precoInicial = Console.ReadLine();
    precoInicialValido = ValidatorHelper.ValidarPrecoInicial(s_precoInicial);
    if (!precoInicialValido)
    {
        Console.WriteLine("Valor digitado não é aceito pelo sistema!");
        Console.WriteLine("Pressione uma tecla para continuar");
        Console.ReadKey();
        Console.Clear();
    }
}
while(!precoInicialValido);

precoInicial = Convert.ToDecimal(s_precoInicial);

do
{
    Console.WriteLine("Agora digite o preço por hora:");
    s_precoPorHora = Console.ReadLine();
    precoPorHoraValido = ValidatorHelper.ValidarPrecoHora(s_precoPorHora);
    if (!precoPorHoraValido)
    {
        Console.WriteLine("Valor digitado não é aceito pelo sistema!");
        Console.WriteLine("Pressione uma tecla para continuar");
        Console.ReadKey();        
        Console.Clear();
    }
}
while(!precoPorHoraValido);
precoPorHora = Convert.ToDecimal(s_precoPorHora);

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
