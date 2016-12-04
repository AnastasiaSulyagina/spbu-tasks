using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public sealed class CoolParentFactory : IHumanFactory
    {
        private const int MaxChildrenNum = 3;
        private const int MaxMoneyNum = 1000000;

        public Human CreateHuman(Sex sex) =>
            new CoolParent(Randomizer.GenerateRandomParentAge(), 
                           Generator.GenerateName(Sex.Male),
                           Sex.Male,
                           Randomizer.GenerateRandomChildrenNum(MaxChildrenNum),
                           Randomizer.GenerateRandomMoneyNum(MaxMoneyNum));

        public Human CreatePair(Human student)
        {
            if (student == null || !(student is Botan))
            {
                throw new ArgumentException("Invalid student");
            }
            Botan botan = (Botan)student;
            if (botan.MidName.Length < 5)
            {
                throw new ArgumentException("Invalid student's middle name");
            }
            var name = Generator.GenerateParentNameFromMidName(botan.MidName);
            return new CoolParent(Randomizer.GenerateRandomParentAge(student.Age), 
                                  name, 
                                  Sex.Male,
                                  1 + Randomizer.GenerateRandomChildrenNum(MaxChildrenNum - 1), 
                                  Generator.GenerateMoneyFromMark(botan.AverageMark));
        }
    }
}
