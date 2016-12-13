using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public class StudentFactory : IHumanFactory
    {
        public virtual Human CreateHuman(Sex sex) =>
            new Student(Randomizer.GenerateRandomYoungHumanAge(), Generator.GenerateName(sex),
                sex, Generator.GenerateMidName(sex));

        public virtual Human CreatePair(Human parent)
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
