namespace Trees.Tries
{
    public class Trie
    {
        public static int ALPHABET_SIZE = 26;
        private class Node
        {
            public char Value { get; set; }
            public Dictionary<char, Node> Children { get; set; } = new Dictionary<char, Node>();
            public bool IsEndOfWord { get; set; }

            public Node(char value)
                => Value = value;

            public override string ToString()
                => "Value=" + Value;

            public bool HasChild(char ch)
                => Children.ContainsKey(ch);


            public void RemoveChild(char ch)
                => Children.Remove(ch);

            public bool HasChildren()
                => !(Children.Count == 0);

            public void AddChild(char ch)
                 => Children[ch] = new Node(ch);

            public Node GetChild(char ch)
                => Children[ch];

            public Node[] GetChildren()
                => Children.Values.ToArray();
        }
        private Node Root { get; init; } = new Node(' ');

        public void Insert(string word)
        {
            var current = Root;
            foreach (var ch in word.ToCharArray())
            {
                if (!current.HasChild(ch))
                    current.AddChild(ch);
                current = current.GetChild(ch);
            }
            current.IsEndOfWord = true;
        }

        public void Delete(string word)
        {
            if (word is null)
                return;
            Delete(Root, word, 0);
        }
        private void Delete(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.IsEndOfWord = false;
                return;
            }
            var ch = word[index];
            var child = root.GetChild(ch);

            if (child is null)
                return;

            Delete(child, word, index + 1);

            if (!child.HasChildren() && !child.IsEndOfWord)
                root.RemoveChild(ch);
        }

        public bool Contains(string word)
        {
            if (word is null)
                return false;

            var current = Root;

            foreach (char ch in word.ToCharArray())
            {
                if (!current.HasChild(ch))
                    return false;
                current = current.GetChild(ch);
            }

            return current.IsEndOfWord;
        }

        public bool ContainsRecursively(string word)
        {
            if (word is null)
                return false;

            return ContainsRecursively(Root, word, 0);
        }

        public List<string> FindWords(string prefix)
        {

            if (prefix is null)
                return null!;

            var lastNode = FindLastNodeOf(prefix);

            var words = new List<string>();
            FindWords(lastNode, prefix, words);

            return words;
        }

        public int CountWords()
        {
            return CountWords(Root);
        }

        private int CountWords(Node root)
        {
            if (root is null)
                return 0;

            int count = root.IsEndOfWord ? 1 : 0;
            
            foreach(var child in root.Children.Values)
            {
                count += CountWords(child);
            } 

            return count;
        }

        private bool ContainsRecursively(Node root, string word, int index)
        {

            if (index == word.Length)
                return root.IsEndOfWord;

            if (!root.HasChild(word[index]))
                return false;

            var child = root.GetChild(word[index]);

            return ContainsRecursively(child, word, index + 1);
        }


        private void FindWords(Node root, string prefix, List<string> words)
        {

            if (root is null)
                return;

            if (root.IsEndOfWord)
                words.Add(prefix);

            foreach(var child in root.GetChildren())
                FindWords(child, prefix + child.Value, words);
        }

        private Node FindLastNodeOf(string Prefix)
        {
            var current = Root;

            foreach(var ch in Prefix.ToCharArray())
            {
                var child = current.GetChild(ch);
                if (child is null)
                    return null!;
                current = child;
            }

            return current;
        }
        public void PostOrderTravese()
        {
            PostOrderTravese(Root);
        }

        private void PostOrderTravese(Node root)
        {
            foreach (var child in Root.GetChildren())
                PostOrderTravese(child);
            Console.WriteLine(Root.Value);
        }

        public void PreOrderTravese()
        {
            PreOrderTravese(Root);
        }

        private void PreOrderTravese(Node root)
        {
            Console.WriteLine(Root.Value);
            foreach (var child in Root.GetChildren())
                PreOrderTravese(child);
        }
    }
}