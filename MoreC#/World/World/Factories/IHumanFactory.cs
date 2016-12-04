using World.Creatures;

namespace World.Factories
{
    public interface IHumanFactory
    {
        Human CreateHuman(Sex sex);
        Human CreatePair(Human human);
    }
}
