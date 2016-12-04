using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public sealed class PrettyGirlFactory : IHumanFactory
    {
        public Human CreateHuman(Sex sex = Sex.Female) =>
            new PrettyGirl(Generator.GenerateName(sex), Generator.GenerateMidName(sex), 
                Randomizer.GenerateRandomYoungHumanAge());

        public Human CreatePair(Human human)
        {
            throw new NotImplementedException();
        }
    }
}
