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
            fixDown();
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

        private bool needToSwap(int? idx1, int? idx2)
        {
            if (idx1 == null || idx2 == null) {
                return false;
            }

            return needToSwap((int) idx1, (int) idx2);
        }

        private void fixUp()
        {
            var idx = Size;
            var pindex = getParent(idx);

            while (needToSwap(pindex, idx))
            {
                var validIdx = (int)pindex;
                swap(idx, validIdx);
                idx = validIdx;

                pindex = getParent(idx);
            }
        }

        private void fixDown()
        {
            var idx = 0;
            Array[idx] = Array[Size];

            while (hasChild(idx)) {
                var cidx = (int)getLeftChild(idx);

                if (needToSwap(cidx, cidx + 1)) {
                    cidx++;
                }

                if (needToSwap(idx, cidx)) {
                    swap(idx, cidx);
                    idx = cidx;
                }
                else {
                    break;
                }
            }
        }

        private int? getParent(int cindex)
        {
            var pindex = (int)(Math.Ceiling((double)cindex / 2) - 1);
            if (pindex >= 0)
            {
                return pindex;
            }

            return null;
        }

        private int? getLeftChild(int pindex)
        {
            var cindex = pindex * 2 + 1;
            if (Size >= cindex)
            {
                return cindex;
            }

            return null;
        }

        private int? getRightChild(int pindex)
        {
            var left = getLeftChild(pindex);
            return left != null ? left + 1 : null;
        }

        private bool hasChild(int pindex) {
            return getLeftChild(pindex) != null;
        }

        private void swap(int idx1, int idx2)
        {
            var tmp = Array[idx1];
            Array[idx1] = Array[idx2];
            Array[idx2] = tmp;
        }



    }
}
