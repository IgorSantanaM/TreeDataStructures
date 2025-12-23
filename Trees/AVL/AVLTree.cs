namespace Trees.AVL
{
    public class AVLTree
    {
        private AVLNode Root { get; set; }

        private class AVLNode
        {
            public int Value { get; set; }
            public AVLNode Left { get; set; }
            public AVLNode Right { get; set; }
            public int Height { get; set; }


            public AVLNode(int value)
            {
                Value = value;
            }
        }

        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }
        private AVLNode Insert(AVLNode node, int value)
        {
            if (node is null)
                return new AVLNode(value);

            if (value < node.Value)
                node.Left = Insert(node.Left, value);
            else
                node.Right = Insert(node.Right, value);

            SetHeight(node);

            return Balance(node);
        }

        private AVLNode Balance(AVLNode root)
        {
            if (IsLeftHeavy(root))
            {
                Console.WriteLine($"the node with the value: {root.Value} is left heavy");
                if (BalanceFactor(root.Left) < 0)
                    root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }
            else if (IsRightHeavy(root))
            {
                Console.WriteLine($"the node with the value: {root.Value} is right heavy");
                if (BalanceFactor(root.Right) > 0)
                    root.Right = RightRotate(root.Right);
                return LeftRotate(root);   
            }

            return root;
        }
        private bool IsBalanced(AVLNode node) => 
            !(IsLeftHeavy(node) || IsRightHeavy(node));
        
        private bool IsPerfect(AVLNode root)
        {
            if (root is null) return true;

            int height = CalculateHeight(root);
            int nodeCount = CountNodes(root);

            int expectedNodes = (int)Math.Pow(2, height - 1) + 1;

            return nodeCount == expectedNodes;
        }

        private int CountNodes(AVLNode node)
        {
            if(node is null) return 0;

            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }

        private AVLNode LeftRotate(AVLNode root)
        {
            var newRoot = root.Right;
            root.Right = newRoot.Left;
            newRoot.Left = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }
        private AVLNode RightRotate(AVLNode root)
        {
            var newRoot = root.Left;
            root.Left = newRoot.Right;
            newRoot.Right = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }
        private void SetHeight(AVLNode node)
        {
            node.Height = Math.Max(CalculateHeight(node.Left), CalculateHeight(node.Right)) + 1;
        }

        private bool IsLeftHeavy(AVLNode node)
        {
            return (BalanceFactor(node)) > 1;
        }
        private bool IsRightHeavy(AVLNode node)
        {
            return (BalanceFactor(node)) < -1;
        }

        private int BalanceFactor(AVLNode node)
        {
            return (node is null) ? 0 : CalculateHeight(node.Left) - CalculateHeight(node.Right);
        }
        private int CalculateHeight(AVLNode node)
        {
            return node is null ? -1 : node.Height;
        }
    }
}
