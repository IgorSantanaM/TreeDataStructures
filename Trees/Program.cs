using Trees;

AVLTree tree = new();

tree.Insert(10);
tree.Insert(20);
tree.Insert(30);

Heap heap = new Heap();
heap.Insert(10);
heap.Insert(20);
heap.Insert(30);
heap.Remove();