using System;

namespace heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new Heap(10);

            for (var i = 1; i <= 10; i++) {
                heap.add(i);
                heap.debug();
            }
        }
    }
}
