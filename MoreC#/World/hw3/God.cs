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
        private readonly Dictionary<Type, IHumanFactory> humanFactories = new Dictionary<Type, IHumanFactory>()
        {
            { typeof(Student), new ParentFactory()},
            { typeof(Parent), new StudentFactory()},
            { typeof(Botan), new CoolParentFactory()},
            { typeof(CoolParent), new BotanFactory()}
        };
        private readonly List<IHumanFactory> factories;
        private readonly List<Human> humans = new List<Human>();
        public God()
        {
            factories = humanFactories.Values.ToList();
        }

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
            var human = factories[rnd.Next(factories.Count)].CreateHuman(sex);
            humans.Add(human);
            return human;
        }

        public Human CreatePair(Human human)
        {
            if (human == null || humanFactories[human.GetType()] == null)
            {
                throw new ArgumentException("Invalid human");
            }
            Human newHuman = humanFactories[human.GetType()].CreatePair(human);
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
