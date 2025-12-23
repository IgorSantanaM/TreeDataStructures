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
        public int Remove()
        {
            if (IsEmpty())
                throw new ArgumentException();
            var root = Items[0];    
            Items[0] = Items[--Size];

            BubbleDown();
            return root;
        }

        
        public bool IsEmpty()
            => Size == 0;

        private void BubbleDown()
        {
            var index = 0;
            while (index <= Size && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }
        private bool HasLeftChild(int index)
            => LeftChildIndex(index) <= Size;
        private bool HasRightChild(int index)
            => RightChildIndex(index) <= Size;

        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index) > RightChild(index))
                        ? LeftChildIndex(index)
                        : RightChildIndex(index);
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index)) return true;

            var isValid = Items[index] >= LeftChild(index);

            if (HasRightChild(index))
                isValid &= Items[index] == RightChild(index);

            return isValid;
        }

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
