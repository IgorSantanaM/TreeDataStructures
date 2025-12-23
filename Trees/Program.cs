using System.Runtime.CompilerServices;
using Trees.AVL;
using Trees.Heap;
using Trees.Tries;

AVLTree tree = new();

tree.Insert(10);
tree.Insert(20);
tree.Insert(30);

Heap heap = new Heap();
heap.Insert(10);
heap.Insert(20);
heap.Insert(30);
heap.Remove();

int[] maxHeapTestArray = [90, 70, 60, 40, 50, 20, 10];
int[] minHeapTestArray = [10, 20, 15, 40, 50, 30, 25];

bool maxResult = heap.IsMaxHeap(maxHeapTestArray);
bool minResult = heap.IsMinHeap(minHeapTestArray);


var trie = new Trie();

trie.Insert("canada");
trie.Insert("soda");
trie.Contains("can");