using System;
using World.Creatures;

namespace World.Services
{
    public sealed class Randomizer
    {
        private static Random Rnd = new Random();

        public static Sex GenerateRandomSex() =>
            (Sex)Enum.GetValues(typeof(Sex)).GetValue(Rnd.Next(2));

        internal static int GenerateRandomYoungHumanAge() => Rnd.Next(7, 20);

        internal static int GenerateRandomParentAge() => Rnd.Next(20, 60);

        internal static int GenerateRandomParentAge(int studentAge) => 
            studentAge + Rnd.Next(20, 40);

        internal static double GenerateRandomAverageMark() => 
            Math.Round(3 + Rnd.NextDouble() * 2, 2);

        internal static int GenerateRandomChildrenNum(int MaxChildrenNum) => 
            Rnd.Next(MaxChildrenNum);

        internal static int GenerateRandomMoneyNum(int MaxMoneyNum) => 
            Rnd.Next(MaxMoneyNum);

        public static bool CheckIfLikes(double probability) => 
            Rnd.NextDouble() < probability;
    }
}
