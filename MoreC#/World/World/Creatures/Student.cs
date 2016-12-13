using System;
using World.Attributes;

namespace World.Creatures
{
    [Couple("Girl", 0.7, "Girl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.5, "Girl")]
    public class Student : Human, IHasMidName
    {
        public Student(int age, String name, Sex sex, String midName) : base(age, name, sex)
        {
            if (String.IsNullOrEmpty(midName))
            {
                throw new ArgumentException("Invalid middle name");
            }
            MidName = midName;
            Color = ConsoleColor.Cyan;
            Type = HumanType.Student;
        }

        public String MidName { get; }

        public override void ToConsole()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine("Student {0} {1}, sex: {2}, age: {3}", Name, MidName, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
