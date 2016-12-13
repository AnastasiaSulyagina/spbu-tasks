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
        private readonly String WorldNameSpace = "Creatures";

        private static readonly Dictionary<Sex, IHumanFactory[]> HumanFactories = 
            new Dictionary<Sex, IHumanFactory[]>() {
                { Sex.Female,
                    new IHumanFactory[] {
                        new GirlFactory(),
                        new PrettyGirlFactory(),
                        new SmartGirlFactory() } },
                { Sex.Male,
                    new IHumanFactory[] {
                        new StudentFactory(),
                        new BotanFactory() } }
            };
        private int girlFactoriesNum = HumanFactories[Sex.Female].Length;
        private int manFactoriesNum = HumanFactories[Sex.Male].Length;

        public Tuple<Human, Human> GenerateHumansForDating()
        {
            return new Tuple<Human, Human>(
                HumanFactories[Sex.Female][rnd.Next(girlFactoriesNum)].CreateHuman(Sex.Female),
                HumanFactories[Sex.Male][rnd.Next(manFactoriesNum)].CreateHuman(Sex.Male));
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
            CoupleAttribute firstAttr = GetAttribute(firstHuman, secondHuman);
            CoupleAttribute secondAttr = GetAttribute(secondHuman, firstHuman);

            if (!Randomizer.CheckIfLikes(firstAttr.Probability) 
                || !Randomizer.CheckIfLikes(secondAttr.Probability))
            {
                return null;
            }

            return MakeChild(
                // different child types - would throw an exception
                firstAttr.ChildType == secondAttr.ChildType ? firstAttr.ChildType : null,
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
                    return Activator.CreateInstance(type, name,
                        Generator.GenerateMidNameFromParentName(Sex.Female, father.Name), NewbornAge)
                        as IHasName;
                }

                return Activator.CreateInstance(type, name) as IHasName;
            }
            catch (Exception e)
            {
                throw new Exception("Child of given type can not be constructed", e);
            }
        }

        private Type GetTypeOfHuman(String type) 
            => Type.GetType($"{WorldProject}.{WorldNameSpace}." + type + $", {WorldProject}");

        private String GetChildsName(Human human)
        {
            var namingMethod = human.GetType().GetMethods()
                .First(x => x.Name == Human.ChildNamingMethod && x.ReturnType == typeof(String));
            try
            {
                return namingMethod.Invoke(human, null) as String;
            }
            catch (Exception e)
            {
                throw new Exception("Child naming is not supported by the human", e);
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
