using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public class ParentFactory: IHumanFactory
    {
        private const int MaxChildrenNum = 3;

        public virtual Human CreateHuman(Sex sex) =>
            new Parent(Randomizer.GenerateRandomParentAge(), Generator.GenerateName(Sex.Male), 
                Sex.Male, Randomizer.GenerateRandomChildrenNum(MaxChildrenNum));

        public virtual Human CreatePair(Human student)
        {
            if (student == null || !(student is Student))
            {
                throw new ArgumentException("Invalid student");
            }
            if (((Student)student).MidName.Length < 5)
            {
                throw new ArgumentException("Invalid student's middle name");
            }

            var name = Generator.GenerateParentNameFromMidName(((Student)student).MidName);
            return new Parent(Randomizer.GenerateRandomParentAge(student.Age), name,
                Sex.Male, 1 + Randomizer.GenerateRandomChildrenNum(MaxChildrenNum - 1));
        }
    }
}
