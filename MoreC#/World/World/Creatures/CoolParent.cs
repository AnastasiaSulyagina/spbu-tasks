using System;

namespace World.Creatures
{
    public sealed class CoolParent : Parent
    {
        public CoolParent(int age, String name, Sex sex, int childrenNum, int money) 
            : base(age, name, sex, childrenNum)
        {
            if (money < 0)
            {
                throw new ArgumentException("Invalid money amount");
            }
            Money = money;
            Color = ConsoleColor.Yellow;
            Type = HumanType.Coolparent;
        }

        public int Money { get; }

        public override void ToConsole()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            ConsoleColor backgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = Color;
            Console.Write("CoolParent {0}, sex: {1}, age: {2}, children: {3}",
                Name, Sex, Age, ChildrenNum);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("${0}", Money);

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }
    }
}
