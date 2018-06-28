using System.Linq;
using AdvanceNetDs.Heap;
using AdvanceNetDs.Shared;
using NUnit.Framework;

namespace AdvanceNetDs.Test.Heap
{
    [TestFixture]
    public class MinHeapTest
    {

        [Test]
        public void Add_DataNodes_Test()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int[] data = {10, 6, 3, 76, 9, 43, 1};
            

            data.ToList().ForEach(s =>minHeap.Add(new Node<int>() {Data = s}));

            Assert.IsTrue(minHeap.PeekMinElement().Data.CompareTo(1) == 0);

            minHeap.RemoveMinElement();
            minHeap.RemoveMinElement();

            Assert.IsTrue(minHeap.PeekMinElement().Data.CompareTo(6) == 0);
        }
    }
}
