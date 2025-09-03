using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Duas variáveis para guardar os preços que o usuário vai informar
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        // Essa lista guardar as placas dos veículos que estão estacionados
        private List<string> veiculos = new List<string>();

        // Esse é o construtor da classe. Ele recebe os preços e salva nas variáveis
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Função para adicionar um veículo na lista
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            // Verifica se a placa não está vazia
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            // Adiciona a placa na lista
            veiculos.Add(placa.ToUpperInvariant());
            Console.WriteLine($"Veículo {placa} estacionado com sucesso.");
        }

        // Função para remover veículo da lista
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se a placa foi digitada corretamente
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            placa = placa.ToUpperInvariant();

            // Verifica se essa placa existe na lista
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string entrada = Console.ReadLine();

                if (!TimeSpan.TryParse(entrada, out TimeSpan tempo))
                {
                    Console.WriteLine("Entrada inválida para horas. Use o formato HH:mm (ex: 4:15).");
                    return;
                }

                decimal horas = (decimal)tempo.TotalHours;

                // Calcula o valor total a pagar
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // Remove a placa da lista
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        // Função para mostrar todos os veículos estacionados
        public void ListarVeiculos()
        {
            // Verifica se tem algum veículo na lista
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                // Uso de um foreach para mostrar cada placa
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
