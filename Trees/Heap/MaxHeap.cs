namespace Trees.Heap
{
    public class MaxHeap
    {
        public static void Heapify(int[] array)
        {
            int lastParent = (array.Length / 2) - 1;
            for (int i = lastParent; i >= 0; i--)
            {
                Heapify(array, i);
            }
        }

        private static void Heapify(int[] array, int index)
        {
            int n = array.Length;
            var largerIndex = index;
            int leftChildIndex = LeftChildIndex(largerIndex);

            if (leftChildIndex < n && array[largerIndex] < array[leftChildIndex])
                largerIndex = leftChildIndex;

            int rightChildIndex = RightChildIndex(index);

            if (rightChildIndex < n && array[largerIndex] < array[rightChildIndex])
                largerIndex = rightChildIndex;

            if (largerIndex == index)
                return;

            Swap(array, index, largerIndex);

            Heapify(array, largerIndex);
        }

        public static int GetKthLargest(int[] array, int k)
        {
            if (k < 1 || k > array.Length)
                throw new ArgumentException();

            var heap = new Heap();

            foreach (var num in array)
                heap.Insert(num);

            for (int i = 0; i < k; i++)
            {
                heap.Remove();
            }

            return heap.Max();
        }

        private static int LeftChildIndex(int index)
            => (index * 2) + 1;

        private static int RightChildIndex(int index)
            => (index * 2) + 2;

        private static void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
