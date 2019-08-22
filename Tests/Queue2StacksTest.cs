using System.Collections.Generic;
using NUnit.Framework;
using Project;
using System.Text;

namespace Tests
{
    public class Queue2StacksTest
    {
        Queue2Stack queue;

        [SetUp]
        public void SetUp()
        {
            queue = new Queue2Stack();
        }
        private static IEnumerable<IEnumerable<int>> Source4TestQueue()
        {
            yield return new int[2] { 2, 1 };
            yield return new int[3] { 1, 3, 2 };
        }

        [TestCaseSource(nameof(Source4TestQueue))]
        public void TestIsQueue(IEnumerable<int> data)
        {
            var queue = new Queue2Stack();
            foreach (var d in data)
            {
                queue.Enqueue(d);
            }
            foreach (var d in data)
            {
                var value = queue.Dequeue();
                Assert.AreEqual(d, value, $"Source data={StringPresentation(data)} , expected={d}, but was {value}");
            }
        }
        [Test]
        public void TestQueue1()
        {
            queue.Enqueue(2);
            queue.Enqueue(23);
            queue.Enqueue(22);
            Assert.AreEqual(2, queue.Dequeue());
            queue.Enqueue(56);
            Assert.AreEqual(23, queue.Dequeue());
            Assert.AreEqual(22, queue.Dequeue());
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(67);
            queue.Enqueue(8);
            Assert.AreEqual(56, queue.Dequeue());
            Assert.AreEqual(5, queue.Dequeue());
        }

        private string StringPresentation(IEnumerable<int> data)
        {
            var sb = new StringBuilder();
            foreach (var d in data)
            {
                sb.AppendFormat($"{d} ");
            }
            return sb.ToString();
        }
    }
}