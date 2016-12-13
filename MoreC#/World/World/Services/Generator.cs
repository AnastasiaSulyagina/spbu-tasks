using System;
using System.Collections.Generic;
using System.Linq;
using World.Creatures;

namespace World.Services
{
    public sealed class Generator
    {
        private static readonly Dictionary<Sex, string[]> Names = new Dictionary<Sex, string[]>() {
            { Sex.Female, new string[]{ "Анна", "Анастасия", "Алиса", "Ксения", "Татьяна"} },
            { Sex.Male, new string[] { "Александр", "Олег", "Владимир", "Кирилл", "Федор" } }
        };
        private static readonly Dictionary<Sex, string> Endings = new Dictionary<Sex, string>() {
            { Sex.Female, "овна"}, { Sex.Male, "ович" }
        };
        private const int EndingLength = 4;
        private static Random Rnd = new Random();

        public static HumanType GetPair(HumanType type)
        {
            switch (type)
            {
                case HumanType.Student:
                    return HumanType.Parent;
                case HumanType.Parent:
                    return HumanType.Student;
                case HumanType.Botan:
                    return HumanType.Coolparent;
                case HumanType.Coolparent:
                    return HumanType.Botan;
                default:
                    throw new NotImplementedException();
            }
        }

        internal static int GenerateMoneyFromMark(double mark) => 
            (int)Math.Pow(10.0, mark);

        internal static double GenerateMarkFromMoney(int money) =>
            (Math.Log10(money) > 5 ? 5 : Math.Log10(money));

        public static string GenerateMidName(Sex sex) =>
            GenerateName(Sex.Male) + Endings[sex];

        public static string GenerateName(Sex sex)
        {
            if (!Names.ContainsKey(sex))
            {
                throw new ArgumentException("Invalid sex");
            }
            return (string)Names[sex].GetValue(Rnd.Next(Names[sex].Length));
        }

        public static string GenerateMidNameFromParentName(Sex sex, string parentName)
        {
            if (!Names.ContainsKey(sex))
            {
                throw new ArgumentException("Invalid child's sex");
            }
            if (Array.IndexOf(Names[Sex.Male], parentName) == -1)
            {
                throw new ArgumentException("Invalid parentName");
            }
            return parentName + Endings[sex];
        }

        internal static string GenerateParentNameFromMidName(string midName)
        {
            if (midName == null || midName.Length <= 4 || !Endings.Values.Contains(
                midName.Substring(midName.Length - EndingLength, EndingLength)))
            {
                throw new ArgumentException("Invalid middle mane");
            }
           
            var name = midName.Substring(0, midName.Length - EndingLength);
            
            if (Array.IndexOf(Names[Sex.Male], name) == -1)
            {
                throw new ArgumentException("Invalid parentName");
            }
            return name;
        }
    }
}
