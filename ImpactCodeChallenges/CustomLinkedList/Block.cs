using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactCodeChallenges.CustomLinkedList
{
    public class Block<T>
    {
        public Block<T> NextElement { get; set; }
        public Block<T> PreviousElement { get; set; }
        public bool FirstElement() => PreviousElement == null;
        public bool LastElment() => NextElement == null;

        public T Value { get; set; }
    }
}
