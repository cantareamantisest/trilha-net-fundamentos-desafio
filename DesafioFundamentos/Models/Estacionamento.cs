using DesafioFundamentos.Helpers;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {       
            Console.WriteLine("Digite uma placa válida do veículo para estacionar:");
            var placa = Console.ReadLine().ToUpper();
            if (ValidatorHelper.ValidarPlaca(placa) && !veiculos.Any(c => c == placa))
            {
                veiculos.Add(placa);
                Console.WriteLine("Veículo adicionado com sucesso!");
            }
            else if (veiculos.Any(c => c == placa))
            {
                Console.WriteLine("Não é possível estacionar esse veículo pois já existe um veículo estacionado com a mesma placa digitada.");
            }
            else
            {
                Console.WriteLine("Placa fora dos padrões aceitos em território nacional.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x == placa))
            {
                bool quantidadeHoraValido = false;
                string s_horas = "";
                int horas = 0;
                decimal valorTotal = 0;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    s_horas = Console.ReadLine();
                    quantidadeHoraValido = ValidatorHelper.ValidarQuantidadeHoras(s_horas);
                    if (!quantidadeHoraValido)
                    {
                        Console.WriteLine("Valor digitado não é aceito pelo sistema!");
                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadKey();
                    }
                }
                while (!quantidadeHoraValido);

                horas = Convert.ToInt32(s_horas);
                valorTotal = (precoPorHora * horas) + precoInicial;

                veiculos.RemoveAll(c => c == placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}