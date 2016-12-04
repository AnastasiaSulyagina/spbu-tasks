using System;
using World.Creatures;
using World.Services;

namespace World.Factories
{
    public sealed class BotanFactory : IHumanFactory
    {
        public Human CreateHuman(Sex sex) =>
            new Botan(Randomizer.GenerateRandomYoungHumanAge(), Generator.GenerateName(sex), sex,
                Generator.GenerateMidName(sex), Randomizer.GenerateRandomAverageMark());

        public Human CreatePair(Human parent)
        {
            if (parent == null || !(parent is CoolParent))
            {
                throw new ArgumentException("Invalid parent");
            }
            var sex = Randomizer.GenerateRandomSex();

            return new Botan(Randomizer.GenerateRandomYoungHumanAge(), 
                             Generator.GenerateName(sex), 
                             sex,
                             Generator.GenerateMidNameFromParentName(sex, parent.Name),
                             Generator.GenerateMarkFromMoney(((CoolParent)parent).Money));
        }
    }
}
