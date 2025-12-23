namespace Trees
{
    public class PriorityQueueWithHeap
    {
        private Heap heap = new Heap();
        public void Enqueue(int item)
          => heap.Insert(item);

        public int Dequeue()
          => heap.Remove();

        public bool IsEmpty()
          => heap.IsEmpty();
    }
}
