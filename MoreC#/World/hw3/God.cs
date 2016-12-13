using System;
using System.Linq;
using System.Collections.Generic;
using World.Creatures;
using World.Services;
using World.Factories;

namespace hw3
{
    public sealed class God: IGod
    {
        private readonly Random rnd = new Random();
        private readonly Dictionary<HumanType, IHumanFactory> humanFactories = 
            new Dictionary<HumanType, IHumanFactory>()
        {
            { HumanType.Parent, new ParentFactory()},
            { HumanType.Student, new StudentFactory()},
            { HumanType.Coolparent, new CoolParentFactory()},
            { HumanType.Botan, new BotanFactory()}
        };
        
        private readonly List<Human> humans = new List<Human>();
        private readonly int factoriesNum = 4;

        public Human CreateHuman()
        {
            switch (humans.Count)
            {
                case 0:
                    return CreateHuman(Sex.Male);
                case 1:
                    return CreateHuman(Sex.Female);
                default:
                    return CreateHuman(Randomizer.GenerateRandomSex());
            }
        }

        public Human CreateHuman(Sex sex)
        {   
            var human = humanFactories.Values.ToList()[rnd.Next(factoriesNum)].CreateHuman(sex);
            humans.Add(human);
            return human;
        }

        public Human CreatePair(Human human)
        {
            if (human == null || humanFactories[Generator.GetPair(human.Type)] == null)
            {
                throw new ArgumentException("Invalid human");
            }
            Human newHuman = humanFactories[Generator.GetPair(human.Type)].CreatePair(human);
            humans.Add(newHuman);
            return newHuman;
        }

        internal Human[] GetHumans() => humans.ToArray();

        internal int this[int index]
        {
            get
            {
                if (index < 0 || index >= humans.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return humans[index] is CoolParent ? (humans[index] as CoolParent).Money : 0;
            }
        }

        internal int GetTotalMoney() => 
            Enumerable.Range(1, humans.Count).Sum(i => this[i]);
    }
}
