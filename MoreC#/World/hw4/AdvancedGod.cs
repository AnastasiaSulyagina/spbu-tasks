using System;
using System.Collections.Generic;
using System.Linq;
using World.Creatures;
using World.Factories;
using World.Services;
using World.Attributes;
using hw4.Exceptions;

namespace hw4
{
    public sealed class AdvancedGod 
    {
        private readonly Random rnd = new Random();
        private readonly int NewbornAge = 0;
        private readonly String WorldProject = "World";

        private static readonly Dictionary<Sex, IHumanFactory[]> Humans = 
            new Dictionary<Sex, IHumanFactory[]>() {
                { Sex.Female,
                    new IHumanFactory[] { new GirlFactory(), new PrettyGirlFactory(), new SmartGirlFactory() } },
                { Sex.Male,
                    new IHumanFactory[] { new StudentFactory(), new BotanFactory() } }
            };
        
        public Tuple<Human, Human> GenerateHumansForDating()
        {
            return new Tuple<Human, Human>(
                Humans[Sex.Female][rnd.Next(Humans[Sex.Female].Count())].CreateHuman(Sex.Female),
                Humans[Sex.Male][rnd.Next(Humans[Sex.Male].Count())].CreateHuman(Sex.Male));
        }

        public IHasName Couple(Human firstHuman, Human secondHuman)
        {
            if (firstHuman == null || secondHuman == null)
            {
                throw new ArgumentNullException();
            }
            if (firstHuman.Sex == secondHuman.Sex)
            {
                throw new WrongCoupleException("Бездуховность!");
            }
            List <CoupleAttribute> attributes = new List<CoupleAttribute>()
                { GetAttribute(firstHuman, secondHuman), GetAttribute(secondHuman, firstHuman) };

            if (!Randomizer.CheckIfLikes(attributes[0].Probability) 
                || !Randomizer.CheckIfLikes(attributes[1].Probability))
            {
                return null;
            }

            return MakeChild(
                // different child types - would throw an exception
                attributes[0].ChildType == attributes[1].ChildType ? attributes[0].ChildType : null,
                firstHuman.Sex == Sex.Female ? firstHuman : secondHuman,
                firstHuman.Sex == Sex.Female ? secondHuman : firstHuman);
        }

        public IHasName Couple(Tuple<Human, Human> humans) => Couple(humans.Item1, humans.Item2);

        private IHasName MakeChild(String childType, Human mother, Human father)
        {
            try
            {
                var type = GetTypeOfHuman(childType);
                var name = GetChildsName(mother);

                var constructor = type.GetConstructors().FirstOrDefault();
                if (constructor.GetParameters().Length > 1)
                {
                    return (IHasName)Activator.CreateInstance(type, name,
                        Generator.GenerateMidNameFromParentName(Sex.Female, father.Name), NewbornAge);
                }

                return (IHasName)Activator.CreateInstance(type, name);
            }
            catch (Exception)
            {
                throw new NotSupportedException("Child of given type can not be constructed");
            }
        }

        private Type GetTypeOfHuman(String type) 
            => Type.GetType($"{WorldProject}.Creatures." + type + $", {WorldProject}");

        private String GetChildsName(Human human)
        {
            var namingMethod = human.GetType().GetMethods()
                .First(x => x.Name == Human.ChildNamingMethod && x.ReturnType == typeof(String));
            try
            {
                return (String)namingMethod.Invoke(human, null);
            }
            catch (Exception)
            {
                throw new NotSupportedException("Child naming is not supported by the human");
            }
        }

        private CoupleAttribute GetAttribute(Human firstHuman, Human secondHuman)
        {
            var enumerator = new CoupleAttributeEnumerator(firstHuman.GetType());
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Pair.Equals(secondHuman.GetType().Name))
                {
                    return enumerator.Current;
                }
            }
            throw new WrongCoupleException("Incompatible types");
        }
    }
}
