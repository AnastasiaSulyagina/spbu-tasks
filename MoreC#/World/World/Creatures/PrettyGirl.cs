using System;
using World.Attributes;

namespace World.Creatures
{
    [Couple("Student", 0.4, "PrettyGirl")]
    [Couple("Botan", 0.1, "PrettyGirl")]
    public sealed class PrettyGirl : Girl
    {
        public PrettyGirl(String name, String midName, int age = 0) : base(name, midName, age)
        {
            Color = ConsoleColor.Magenta;
        }

        public override void ToConsole()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine("Pretty Girl {0} {1}, sex: {2}, age: {3}", Name, MidName, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
