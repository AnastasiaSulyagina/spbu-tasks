using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public sealed class StudentFactory : IHumanFactory
    {
        public Human CreateHuman(Sex sex) =>
            new Student(Randomizer.GenerateRandomYoungHumanAge(), Generator.GenerateName(sex),
                sex, Generator.GenerateMidName(sex));

        public Human CreatePair(Human parent)
        {
            if (parent == null || !(parent is Parent))
            {
                throw new ArgumentException("Invalid parent");
            }
            var sex = Randomizer.GenerateRandomSex();
            return new Student(Randomizer.GenerateRandomYoungHumanAge(), Generator.GenerateName(sex),
                sex, Generator.GenerateMidNameFromParentName(sex, parent.Name));
        }
    }
}
