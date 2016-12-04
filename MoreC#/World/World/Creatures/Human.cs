using System;
using World.Services;

namespace World.Creatures
{
    public class Human : IHasName
    {
        public static String ChildNamingMethod = "GiveName";

        public Human(int age, String name, Sex sex)
        {
            if ((age < 0) || String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid human");
            }
            Age = age;
            Name = name;
            Sex = sex;
        }

        public int Age { get; }
        public String Name { get; }
        public Sex Sex { get; }
        protected ConsoleColor Color { get; set; }

        public String GiveName() => Generator.GenerateName(Sex.Female);

        public virtual void ToConsole()
        {
            Console.WriteLine("Human {0}, sex: {1}, age: {2}", Name, Sex, Age);
        }
    }

    public enum Sex
    {
        Male,
        Female
    }
}
