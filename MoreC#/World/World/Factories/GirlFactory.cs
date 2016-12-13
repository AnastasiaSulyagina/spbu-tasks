using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public class GirlFactory : IHumanFactory
    {
        public virtual Human CreateHuman(Sex sex = Sex.Female) =>
            new Girl(Generator.GenerateName(sex), Generator.GenerateMidName(sex), 
                Randomizer.GenerateRandomYoungHumanAge());
        
        public virtual Human CreatePair(Human human)
        {
            throw new NotImplementedException();
        }
    }
}
