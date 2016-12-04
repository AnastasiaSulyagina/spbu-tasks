using System;

namespace World.Creatures
{
    public class Book : IHasName
    {
        public Book(String name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid book name");
            }
            Name = name;
        }
        public String Name { get; }

        public override string ToString() => "Book " + Name;
    }
}
