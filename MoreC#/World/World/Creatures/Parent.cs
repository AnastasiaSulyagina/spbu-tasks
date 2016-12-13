using System;

namespace World.Creatures
{
    public class Parent : Human
    {
        public Parent(int age, String name, Sex sex, int childrenNum) : base(age, name, sex, childrenNum)
        {
            if (childrenNum < 0)
            {
                throw new ArgumentException("Invalid children number");
            }
            Color = ConsoleColor.Red;
            Type = HumanType.Parent;
        }

        public override void ToConsole()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine("Parent {0}, sex: {1}, age: {2}, children: {3}",
                Name, Sex, Age, ChildrenNum);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
