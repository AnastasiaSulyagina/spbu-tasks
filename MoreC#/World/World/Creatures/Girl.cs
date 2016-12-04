using System;
using World.Attributes;

namespace World.Creatures
{
    [Couple("Student", 0.7, "Girl")]
    [Couple("Botan", 0.3, "SmartGirl")]
    public class Girl : Human
    {
        public Girl(String name, String midName, int age = 0) : base(age, name, Sex.Female)
        {
            if (String.IsNullOrEmpty(midName))
            {
                throw new ArgumentException("Invalid middle name");
            }
            MidName = midName;
            Color = ConsoleColor.Red;
        }

        public String MidName { get; }

        public override void ToConsole()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine("Girl {0} {1}, sex: {2}, age: {3}", Name, MidName, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
