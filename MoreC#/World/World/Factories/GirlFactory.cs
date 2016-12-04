using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public sealed class GirlFactory : IHumanFactory
    {
        public Human CreateHuman(Sex sex = Sex.Female) =>
            new Girl(Generator.GenerateName(sex), Generator.GenerateMidName(sex), 
                Randomizer.GenerateRandomYoungHumanAge());
        
        public Human CreatePair(Human human)
        {
            throw new NotImplementedException();
        }
    }
}
