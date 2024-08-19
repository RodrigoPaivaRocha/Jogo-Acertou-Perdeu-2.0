using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acertouPerdeu2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao jogo Acertou, perdeu!");
            int numeroDeJogadores = 0;

            // Solicitar o número de jogadores
            while (numeroDeJogadores < 2 || numeroDeJogadores > 5)
            {
                Console.Write("Digite o número de jogadores (entre 2 e 5): ");
                numeroDeJogadores = int.Parse(Console.ReadLine());
            }

            // Criar um array para armazenar os nomes dos jogadores
            string[] jogadores = new string[numeroDeJogadores];

            // Coletar os nomes dos jogadores
            for (int i = 0; i < numeroDeJogadores; i++)
            {
                Console.Write($"Digite o nome do jogador {i + 1}: ");
                jogadores[i] = Console.ReadLine();
            }

            // Gerar o número oculto aleatório entre 1 e 100
            Random random = new Random();
            int numeroOculto = random.Next(1, 101);
            int minimo = 1;
            int maximo = 100;
            bool acertou = false;

            // Início do jogo
            while (!acertou)
            {
                for (int i = 0; i < numeroDeJogadores; i++)
                {
                    Console.WriteLine($"\n{jogadores[i]}, é a sua vez!");

                    int palpite = 0;
                    bool palpiteValido = false;

                    // Solicitar um palpite válido
                    while (!palpiteValido)
                    {
                        Console.Write($"Digite um número entre {minimo} e {maximo}: ");
                        palpite = int.Parse(Console.ReadLine());

                        if (palpite >= minimo && palpite <= maximo)
                        {
                            palpiteValido = true;
                        }
                        else
                        {
                            Console.WriteLine("Palpite inválido! Tente novamente.");
                        }
                    }

                    // Verificar o palpite
                    if (palpite < numeroOculto)
                    {
                        Console.WriteLine("O número oculto é maior!");
                        minimo = palpite + 1;
                    }
                    else if (palpite > numeroOculto)
                    {
                        Console.WriteLine("O número oculto é menor!");
                        maximo = palpite - 1;
                    }
                    else
                    {
                        Console.WriteLine($"Parabéns, {jogadores[i]}! Você acertou o número oculto, que era {numeroOculto}! Sendo assim, VOCÊ PERDEU!");
                        acertou = true;
                        break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
