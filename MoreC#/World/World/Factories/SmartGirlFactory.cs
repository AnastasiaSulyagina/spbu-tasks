using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public sealed class SmartGirlFactory : GirlFactory
    {
        public override Human CreateHuman(Sex sex = Sex.Female) =>
            new SmartGirl(Generator.GenerateName(sex), Generator.GenerateMidName(sex), 
                Randomizer.GenerateRandomYoungHumanAge());

        public override Human CreatePair(Human human)
        {
            throw new NotImplementedException();
        }
    }
}
