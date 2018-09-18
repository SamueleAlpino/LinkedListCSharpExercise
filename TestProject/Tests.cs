using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LinkedListExercise;

namespace TestProject
{
    [TestClass]
    public class Tests
    {
        private LinkedListCS<int> linkedList = new LinkedListCS<int>();

        [TestMethod]
        public void CheckAddFirst()
        {
            linkedList.AddFirst(1);
            Assert.AreEqual(linkedList.First.Value, 1);
            Assert.AreEqual(linkedList.Last.Value, 1);
        }

        [TestMethod]
        public void CheckAddLast()
        {
            linkedList.AddLast(1);
            Assert.AreEqual(linkedList.Last.Value, 1);
            Assert.AreEqual(linkedList.First.Value, 1);
        }

        [TestMethod]
        public void EmptyList()
        {
            Action action = new Action(linkedList.RemoveFirst);
            Assert.ThrowsException<Exception>(action);
        }

        [TestMethod]
        public void CountZeroAtStart()
        {
            Assert.AreEqual((int)linkedList.Count, 0);
        }

        [TestMethod]
        public void AddMethodAddOnlyOneElement()
        {
            Random random = new Random();
            linkedList.AddFirst(random.Next());
            Assert.AreEqual((int)linkedList.Count, 1);
        }

        [TestMethod]
        public void CheckClear()
        {
            Random random = new Random();

            for (int i = 0; i < random.Next(10); i++)
            {
                linkedList.AddFirst(random.Next());
            }

            linkedList.Clear();

            Assert.AreEqual((int)linkedList.Count, 0);
        }

        [TestMethod]
        public void CheckContainsAndFind()
        {
            Random random = new Random();

            for (int i = 0; i < random.Next(10); i++)
            {
                linkedList.AddFirst(random.Next());
            }
            linkedList.AddFirst(40);

            LinkedListNodeCS<int> test = linkedList.Find(40);
            Assert.IsNotNull(test);
            Assert.AreEqual(test, linkedList.Find(40));
        }

        [TestMethod]
        public void CheckNotContains()
        {
            Random random = new Random();

            for (int i = 0; i < random.Next(10); i++)
            {
                linkedList.AddFirst(random.Next());
            }

            LinkedListNodeCS<int> test = linkedList.Find(40);
            Assert.IsNull(test);
        }

        [TestMethod]
        public void CheckRemoveFirst()
        {
            linkedList.AddLast(1);
            linkedList.AddLast(2);

            linkedList.RemoveFirst();

            Assert.AreEqual(linkedList.Last.Value, 2);
            Assert.AreEqual(linkedList.First.Value, 2);
        }

        [TestMethod]
        public void CheckRemove()
        {
            for (int i = 0; i < 4; i++)
            {
                linkedList.AddLast(i);
            }

            linkedList.Remove(linkedList.Find(2));

            Assert.AreEqual(linkedList.Last.Value, 3);
            Assert.AreEqual(linkedList.Last.Prev.Value, 1);
            Assert.IsNull(linkedList.Find(2));
        }

        [TestMethod]
        public void CheckRemoveLastAndFirst()
        {
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);

            linkedList.RemoveLast();

            Assert.AreEqual(linkedList.Last.Value, 2);
            Assert.AreEqual(linkedList.First.Value, 3);

            linkedList.RemoveFirst();

            Assert.AreEqual(linkedList.Last.Value, 2);
            Assert.AreEqual(linkedList.Last.Value, linkedList.First.Value);

        }

        [TestMethod]
        public void CheckAddBefore()
        {
            for (int i = 0; i < 5; i++)
                linkedList.AddLast(i);

            linkedList.AddBefore(linkedList.Find(3), 10);

            Assert.AreEqual((int)linkedList.Count, 6);
            Assert.AreEqual(linkedList.Find(3).Prev.Value, 10);
            Assert.AreEqual(linkedList.Find(10).Next.Value, 3);
        }

        [TestMethod]
        public void CheckAddAfter()
        {
            for (int i = 0; i < 5; i++)
                linkedList.AddLast(i);

            linkedList.AddAfter(linkedList.Find(3), 10);

            Assert.AreEqual((int)linkedList.Count, 6);
            Assert.AreEqual(linkedList.Find(10).Prev.Value, 3);
            Assert.AreEqual(linkedList.Find(3).Next.Value, 10);
            Assert.AreEqual(linkedList.Find(2).Prev.Value, 1);
        }

    }
}
