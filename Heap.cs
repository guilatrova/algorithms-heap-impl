using System;

namespace heaps
{
    public class Heap
    {
        private int Size { get; set; }
        private int[] Array { get; set; }
        public int MaxSize { get { return this.Array.Length; } }

        public HeapOrientation Orientation { get; private set; }

        public Heap(int maxSize, HeapOrientation orientation = HeapOrientation.MAX)
        {
            this.Array = new int[maxSize];
            this.Orientation = orientation;
            this.Size = 0;
        }

        public void add(int value)
        {
            this.Array[this.Size] = value;
            this.fixUp();
            this.Size++;
        }

        public int pop()
        {
            var value = this.Array[0];
            this.Size--;
            // TODO: Fix down
            return value;
        }

        public void debug()
        {
            for (var i = 0; i < Size; i++)
            {
                var n = Array[i];
                System.Console.WriteLine($"* {n}");
            }
        }

        private bool needToSwap(int idx1, int idx2)
        {
            if (idx1 == idx2)
            {
                return false;
            }

            if (idx1 < 0 || idx2 < 0)
            {
                return false;
            }

            if (Orientation == HeapOrientation.MAX) {
                return Array[idx1] < Array[idx2];
            }

            return Array[idx1] > Array[idx2];

        }

        private bool needToSwap((int, int)? group1, int idx2)
        {
            if (group1 == null)
            {
                return false;
            }

            var (_, g1index) = group1 ?? default;
            return needToSwap(g1index, idx2);
        }

        private void fixUp()
        {
            var idx = Size;
            var parentCheck = getParent(idx);

            while (needToSwap(parentCheck, idx))
            {
                var (_, pindex) = parentCheck ?? default;
                swap(idx, pindex);
                idx = pindex;
                parentCheck = getParent(idx);
            }
        }

        private (int, int)? getLeftChild(int pindex)
        {
            var cindex = pindex * 2 + 1;
            if (Size > cindex)
            {
                var cval = Array[cindex];
                return (cval, cindex);
            }

            return null;
        }

        private (int, int)? getRightChild(int pindex)
        {
            var cindex = pindex * 2 + 2;
            if (Size > cindex)
            {
                var cval = Array[cindex];
                return (cval, cindex);
            }

            return null;
        }

        private (int, int)? getParent(int cindex)
        {
            var pindex = (int)(Math.Ceiling((double)cindex / 2) - 1);
            if (pindex >= 0)
            {
                return (Array[pindex], pindex);
            }

            return null;
        }

        private void swap(int idx1, int idx2)
        {
            var tmp = Array[idx1];
            Array[idx1] = Array[idx2];
            Array[idx2] = tmp;
        }



    }
}
