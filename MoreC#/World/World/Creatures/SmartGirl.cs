using System;
using World.Attributes;

namespace World.Creatures
{
    [Couple("Student", 0.2, "Girl")]
    [Couple("Botan", 0.5, "Book")]
    public sealed class SmartGirl : Girl
    {
        public SmartGirl(String name, String midName, int age = 0) : base(name, midName, age)
        {
            Color = ConsoleColor.DarkRed;
        }

        public override void ToConsole()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine("Smart Girl {0} {1}, sex: {2}, age: {3}", Name, MidName, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
