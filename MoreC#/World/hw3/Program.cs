using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using World.Creatures;

namespace hw3
{
    internal sealed class Program
    {
        private const string outputFile = "money.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(Properties.Resources.Hello);
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine(Properties.Resources.DayOff);
                return;
            }

            var humansNum = -1;
            while (humansNum <= 0)
            {
                Console.WriteLine(Properties.Resources.HumansNumber);
                int.TryParse(Console.ReadLine().Trim(), out humansNum);
                if (humansNum <= 0)
                {
                    Console.WriteLine(Properties.Resources.InvalidHumansNumber);
                }
            }

            God god = new God();
            PrintAllHumans(god, humansNum);
            PrintMoneyToFile(god);
        }

        private static void PrintAllHumans(God god, int humansNum)
        {
            var humans = GenerateHumans(god, humansNum);
            PrintHumansToConsole(humans);
            PrintPairsToConsole(GeneratePairs(god, humans));
        }

        private static List<Human> GenerateHumans(God god, int humansNum) =>
            Enumerable.Range(1, humansNum).Select(i => god.CreateHuman()).ToList();

        private static List<Human> GeneratePairs(God god, List<Human> humans) =>
            humans.Select(human => god.CreatePair(human)).ToList();

        private static void PrintHumansToConsole(List<Human> humans)
        {
            foreach (Human human in humans)
            {
                human.ToConsole();
                Console.WriteLine();
            }
        }
        private static void PrintPairsToConsole(List<Human> pairs)
        {
            Console.SetCursorPosition(0, Console.CursorTop - pairs.Count * 2 + 1);
            ConsoleColor background = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Gray;
            foreach (Human pair in pairs)
            {
                pair.ToConsole();
                Console.SetCursorPosition(0, Console.CursorTop + 1);
            }
            Console.BackgroundColor = background;
        }

        private static void PrintMoneyToFile(God god)
        {
            File.WriteAllText(outputFile, god.GetTotalMoney().ToString());
            Console.WriteLine(String.Format(Properties.Resources.MoneyDumped, outputFile));
        }
    }
}
