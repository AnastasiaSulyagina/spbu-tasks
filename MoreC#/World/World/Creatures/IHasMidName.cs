using System;

namespace World.Creatures
{
    public interface IHasMidName : IHasName
    {
        String MidName { get; }
    }
}
