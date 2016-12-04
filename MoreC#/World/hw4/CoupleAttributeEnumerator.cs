using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using World.Attributes;
using World.Creatures;

namespace hw4
{
    class CoupleAttributeEnumerator : IEnumerator<CoupleAttribute>
    {
        private List<CoupleAttribute> attributes;
        private IEnumerator enumerator;

        public CoupleAttributeEnumerator(Type humanType)
        {
            if (humanType == null)
            {
                throw new ArgumentNullException();
            }
            attributes =((CoupleAttribute[])Attribute.GetCustomAttributes(humanType, 
                typeof(CoupleAttribute))).ToList();
            enumerator = attributes.GetEnumerator();
        }

        public CoupleAttribute Current => (CoupleAttribute)enumerator.Current;

        object IEnumerator.Current => enumerator.Current;

        public void Dispose() { }

        public bool MoveNext() => enumerator.MoveNext();

        public void Reset() => enumerator.Reset();
    }
}
