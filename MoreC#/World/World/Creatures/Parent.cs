using System;

namespace World.Creatures
{
    public class Parent : Human
    {
        public Parent(int age, String name, Sex sex, int childrenNum) : base(age, name, sex)
        {
            if (childrenNum < 0)
            {
                throw new ArgumentException("Invalid children number");
            }
            ChildrenNum = childrenNum;
            Color = ConsoleColor.Red;
        }

        public int ChildrenNum { get; }

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
