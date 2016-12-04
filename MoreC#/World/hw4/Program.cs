using System;
using World.Creatures;

namespace hw4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(Properties.Resources.Hello);
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine(Properties.Resources.DayOff);
                return;
            }

            var god = new AdvancedGod();
            bool shouldExit = false;

            while (!shouldExit)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    TryDate(god);
                }
                else if(key.Key == ConsoleKey.Q || key.Key == ConsoleKey.F10)
                {
                    shouldExit = true;
                }
            }

        }
        private static void TryDate(AdvancedGod god)
        {
            var humans = god.GenerateHumansForDating();
            humans.Item1.ToConsole();
            humans.Item2.ToConsole();
            try
            {
                var child = god.Couple(humans);
                Console.Write("       ");
                if (child == null)
                {
                    Console.WriteLine("Did not like each other");
                }
                else
                {
                    if (child is Book)
                    {
                        Console.WriteLine(child.ToString());
                    }
                    else
                    {
                        ((Human)child).ToConsole();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}
