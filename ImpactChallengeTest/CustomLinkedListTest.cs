using ImpactCodeChallenges.CustomLinkedList;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpactChallengeTest
{
    public class CustomLinkedListTest
    {


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void EvaluateFirstElement(int element)
        {
            var customLinkedList = new ImpactLinkedList<int>();
            customLinkedList.AddFirst(element);
            Assert.IsTrue(element == customLinkedList.FirstElement.Value);
        }


        [Test]
        public void EvaluateReversedLoop()
        {
            var customLinkedList = new ImpactLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                customLinkedList.AddFirst(i);
            }
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(customLinkedList.FirstElement.Value > customLinkedList.LastElement.Value);
                customLinkedList.RemoveFirst();
                customLinkedList.RemoveLast();
            }
        }

        [Test]
        public void ThrowIndexOutOfRangeExceptionException()
        {
            var customLinkedList = new ImpactLinkedList<int>();
            Assert.Throws<IndexOutOfRangeException>(
                delegate
                {
                    var first = customLinkedList.FirstElement;
                });
            Assert.Throws<IndexOutOfRangeException>(
                delegate
                {
                    var last = customLinkedList.LastElement;
                });
        }

        [Test]
        public void CheckNextElement()
        {
            var customLinkedList = new ImpactLinkedList<int>();
            customLinkedList.AddFirst(1);
            customLinkedList.AddLast(2);
            var first = customLinkedList.FirstElement;
            var second = customLinkedList.LastElement;
            Assert.IsTrue(first.NextElement == second);
        }

        [Test]
        public void CheckPreviousElement()
        {
            var customLinkedList = new ImpactLinkedList<int>();
            customLinkedList.AddFirst(1);
            customLinkedList.AddLast(2);
            var first = customLinkedList.FirstElement;
            var second = customLinkedList.LastElement;
            Assert.IsTrue(second.PreviousElement == first);
        }

        [Test]
        public void NoPreviousForFirstElement()
        {
            var customLinkedList = new ImpactLinkedList<int>();
            customLinkedList.AddFirst(1);
            var first = customLinkedList.FirstElement;
            Assert.IsNull(first.NextElement);
        }

        [Test]
        public void NoNextForLastElement()
        {
            var customLinkedList = new ImpactLinkedList<int>();
            customLinkedList.AddFirst(1);
            customLinkedList.AddFirst(2);
            var first = customLinkedList.FirstElement;
            var second = customLinkedList.LastElement;
            Assert.IsNotNull(first.NextElement);
            Assert.IsNull(second.NextElement);
        }
    }
}
