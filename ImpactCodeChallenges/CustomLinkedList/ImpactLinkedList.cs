using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactCodeChallenges.CustomLinkedList
{
    public class ImpactLinkedList<T>:IImpactinkedList<T>
    {
        public ImpactLinkedList()
        {
            this.Structure = new Block<T>[0];
        }
        private Block<T> firstElement { get; }

        public Block<T> FirstElement
        {
            get
            {
                if (this.Structure.Length == 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.Structure[0];
            }
        }

        private Block<T> lastElement { get; }

        public Block<T> LastElement
        {
            get
            {
                if (this.Structure.Length == 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.Structure[Structure.Length - 1];
            }
        }
        private Block<T>[] Structure { get; set; }

        public void AddFirst(T element)
        {
            var newBlock = new Block<T>
            {
                Value = element,
                PreviousElement = null,
                NextElement = null,
            };
            if (this.Structure.Count() == 0)
            {
                this.Structure = new Block<T>[] { newBlock };
            }
            else
            {
                var temporaryObject = (Block<T>[])this.Structure.Clone();
                this.Structure = new Block<T>[temporaryObject.Length + 1];
                this.Structure[0] = newBlock;
                temporaryObject.CopyTo(this.Structure, 1);
                this.Structure[0].NextElement = this.Structure[1];
                this.Structure[1].PreviousElement = this.Structure[0];
            }
        }

        public void AddLast(T element)
        {
            var newBlock = new Block<T>
            {
                Value = element,
                PreviousElement = null,
                NextElement = null,
            };
            if (this.Structure.Count() == 0)
            {
                this.Structure = new Block<T>[] { newBlock };
            }
            else
            {
                var temporaryObject = (Block<T>[])this.Structure.Clone();
                this.Structure = new Block<T>[temporaryObject.Length + 1];
                var lastIndex = Structure.Length - 1;
                this.Structure[lastIndex] = newBlock;
                temporaryObject.CopyTo(this.Structure, 0);
                this.Structure[lastIndex].PreviousElement = this.Structure[lastIndex - 1];
                this.Structure[lastIndex - 1].NextElement = this.Structure[lastIndex];
            }
        }

        public void RemoveFirst()
        {
            if (this.Structure.Length == 1)
            {
                this.Structure = new Block<T>[0];
                return;
            }
            if (this.Structure.Length > 1)
            {
                var temporaryObject = (Block<T>[])this.Structure.Clone();
                this.Structure = new Block<T>[temporaryObject.Length - 1];
                for (int i = 0; i < Structure.Length; i++)
                {
                    Structure[i] = temporaryObject[i + 1];
                }
                this.Structure[0].PreviousElement = null;
                return;
            }
        }

        public void RemoveLast()
        {
            if (this.Structure.Length == 1)
            {
                this.Structure = new Block<T>[0];
                return;
            }
            if (this.Structure.Length > 1)
            {
                var temporaryObject = (Block<T>[])this.Structure.Clone();
                this.Structure = new Block<T>[temporaryObject.Length - 1];
                for (int i = 0; i < Structure.Length; i++)
                {
                    Structure[i] = temporaryObject[i];
                }
                var lastIndex = Structure.Length - 1;
                this.Structure[lastIndex].NextElement = null;
                return;
            }
        }

        public int Length()
        {
            return this.Structure.Length;
        }
    }
}
