using System;
using System.Collections.Generic;

namespace World.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class CoupleAttribute: Attribute
    {
        private HashSet<String> PairClasses = 
            new HashSet<String>() { "Student", "Botan", "Girl", "PrettyGirl", "SmartGirl" };
        private HashSet<String> ChildClasses =
            new HashSet<String>() { "Student", "Botan", "Girl", "PrettyGirl", "SmartGirl", "Book" };
        public string Pair { get; }
        public double Probability { get; }
        public string ChildType { get; }

        public CoupleAttribute(string pair, double probability, string childType)
        {
            if (!PairClasses.Contains(pair) || !ChildClasses.Contains(childType))
            {
                throw new ArgumentException("Invalid couple classes");
            }
            if (probability < 0 || probability > 1)
            {
                throw new ArgumentOutOfRangeException("Invalid probability");
            }

            Pair = pair;
            Probability = probability;
            ChildType = childType;
        }
    }
}
