using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactCodeChallenges.CustomLinkedList
{
    interface IImpactinkedList<T>
    {
        void AddFirst(T element);
        void AddLast(T element);
        void RemoveFirst();
        void RemoveLast();
    }
}
