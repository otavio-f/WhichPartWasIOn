using System;
using System.Collections.Generic;
using WhichPartWasIOn.Repository;

namespace WhichPartWasIOn
{
    class Program
    {
        private static SeriesRepository series = new SeriesRepository();
        static void Main(string[] args)
        {
            ShowMenu();
        }

        private static void ShowMenu()
        {
            Console.Clear();
            List<string> options = new() { "1 - Séries", "2 - Anime", "3 - Filmes", "4 - Quadrinho", "5 - Mangá", "6 - Filme", "ESC - Sair" };
            WriteCentered("Pressione as teclas numéricas para escolher uma opção.");
            Console.WriteLine();
            options.ForEach(item => { Console.WriteLine(item); });
            var selected = Console.ReadKey();
            switch(selected.Key)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    NotifyInvalidOption();
                    ShowMenu();
                    break;
            }

        }

        private static void NotifyInvalidOption()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            WriteCentered("Opção Inválida.");
            Console.ForegroundColor = ConsoleColor.White;
            WriteCentered("Por favor selecione uma opção entre as mostradas.");
            WriteCentered("Pressione uma tecla para voltar.");
            Console.ReadKey();

        }

        private static void WriteCentered(string text)
        {
            var padSize = text.Length / 2 + Console.BufferWidth / 2;
            Console.WriteLine(text.PadLeft(padSize));
        }
    }
}
