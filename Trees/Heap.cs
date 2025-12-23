namespace Trees
{
    public class Heap
    {
        public int[] Items { get; set; } = new int[10];
        private int Size { get; set; }

        public void Insert(int value)
        {
            if (IsFull())
                throw new ArgumentException();

            Items[Size++] = value;

            BubbleUp();
        }
        public void Remove()
        {
            if (IsEmpty())
                throw new ArgumentException();

            Items[0] = Items[--Size];

            BubbleDown();
        }

        public bool IsEmpty()
            => Size == 0;

        private void BubbleDown()
        {
            var index = 0;
            while ( index <= Size && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private int LargerChildIndex(int index)
            => (LeftChild(index) > RightChild(index))
                    ? LeftChild(index)
                    : RightChild(index);


        private bool IsValidParent(int index) 
            => Items[index] >= LeftChild(index) && Items[index] >= RightChild(index);

        private int LeftChild(int index)
            => Items[LeftChildIndex(index)];

        private int RightChild(int index)
            => Items[RightChildIndex(index)];

        private int LeftChildIndex(int index)
            => (index * 2) + 1;
        private int RightChildIndex(int index)
            => (index * 2) + 2;

        private bool IsFull()
            => Size == Items.Length;

        private void BubbleUp()
        {
            var index = Size - 1;

            while (index > 0 && Items[index] > Items[ParentIndex(index)])
            {
                Swap(index, ParentIndex(index));
                index = ParentIndex(index);
            }
        }

        private int ParentIndex(int index)
            => (index - 1) / 2;

        private void Swap(int first, int second)
        {
            var temp = Items[first];
            Items[first] = Items[second];
            Items[second] = temp;
        }

    }
}
