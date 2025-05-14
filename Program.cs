using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int escolhas;

            Console.WriteLine("-----------------CALCULADORA 1.0--------------------");
            // Loop principal, ele fica no programa até o usuário escolher sair
            while (true)
            {
                double n1 = 0, n2 = 0; // Declarando dentro do while para resetar a cada nova iteração
                double resultado = 0; //Declarando o resultado aqui para resetar a cada nova iteração
                ExibirMenu();
                // Lê a opção do usuário e verifica se é um número válido
                if (!int.TryParse(Console.ReadLine(), out escolhas) || escolhas < 1 || escolhas > 4)
                {
                    Console.WriteLine("ESCOLHA UMA OPÇÃO VÁLIDA");
                    continue;
                }

                // O que o código fará com a opção escolhida
                switch (escolhas)
                {
                    case 1:
                        NumsUmeDois(ref n1, ref n2); // Passando as variáveis por referência
                        resultado = Soma(n1, n2);
                        Console.WriteLine($"A soma de {n1} e {n2} é igual a {resultado}");
                        SalvarNoHistorico($"Soma: {n1} + {n2} = {resultado}");
                        Console.ReadKey(); // Espera o usuário pressionar qualquer tecla antes de prosseguir
                        Console.Clear(); // Limpa a tela para fins de organização
                        break;

                    case 2:
                        NumsUmeDois(ref n1, ref n2);
                        resultado = Subtracao(n1, n2);
                        Console.WriteLine($"A subtração de {n1} e {n2} é igual a {resultado}");
                        SalvarNoHistorico($"Subtração: {n1} - {n2} = {resultado}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        ExibirHistorico();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Até logo!");
                        return;
                }
            }

            //Exibição do Menu Principal
            static void ExibirMenu()
            {
                Console.WriteLine("1-SOMA\n2-SUBTRAÇÃO\n3-HISTÓRICO\n4-SAIR");
                Console.Write("\nEscolha uma opção: ");

            }

            // Método que lê a entrada do usuário, valida e atribui os valores às variáveis
            static void NumsUmeDois(ref double n1, ref double n2)
            {
                bool sucesso1 = false, sucesso2 = false;
                while (!sucesso1 || !sucesso2)
                {
                    Console.Write("Digite o primeiro número: ");
                    sucesso1 = double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out n1);
                    Console.Write("Digite o segundo número: ");
                    sucesso2 = double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out n2);

                    if (!sucesso1 || !sucesso2)
                    {
                        Console.WriteLine("\nDIGITE NÚMEROS VÁLIDOS\n");
                    }
                }
            }
            // Método para realizar a soma dos dois números
            static double Soma(double n1, double n2)
            {
                return n1 + n2;
            }
            // Método para realizar a subtração dos dois números
            static double Subtracao(double n1, double n2)
            {
                return n1 - n2;
            }
            // Método para salvar a operação no histórico
            static void SalvarNoHistorico(string operacao)
            {
                string caminhoHistorico = Path.Combine(Directory.GetCurrentDirectory(), "historico.txt");

                // Adiciona a operação ao final do arquivo
                File.AppendAllText(caminhoHistorico, operacao + Environment.NewLine);
            }
            static void ExibirHistorico()
            {
            string caminhoHistorico = Path.Combine(Directory.GetCurrentDirectory(), "historico.txt");

                // Verifica se o arquivo existe
                // Se existir, lê o conteúdo e exibe
                if (File.Exists(caminhoHistorico))
                {
                    string[] historico = File.ReadAllLines(caminhoHistorico);
                    Console.WriteLine("Histórico de Operações:\n");
                    foreach (string linha in historico)
                    {
                        Console.WriteLine(linha);
                    }
                }
                else //Se não há nada, essa mensagem é exibida
                {
                    Console.WriteLine("\nNenhum histórico encontrado.\n");
                }
            }
        }
    }
}
