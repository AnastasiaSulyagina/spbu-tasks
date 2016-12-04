using System;
using World.Attributes;

namespace World.Creatures
{
    [Couple("Girl", 0.7, "SmartGirl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.8, "Book")]
    public sealed class Botan : Student
    {
        internal Botan(int age, String name, Sex sex, String midName, double averageMark) :
            base(age, name, sex, midName)
        {
            if ((averageMark < 0) && (averageMark > 5))
            {
                throw new ArgumentException("Invalid average mark");
            }
            AverageMark = averageMark;
            Color = ConsoleColor.DarkCyan;
        }

        public double AverageMark { get; }

        public override void ToConsole()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine("Botan {0} {1}, sex: {2}, age: {3}, average mark: {4}.", 
                Name, MidName, Sex, Age, AverageMark);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
