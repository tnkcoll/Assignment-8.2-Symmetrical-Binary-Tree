using System.ComponentModel.Design.Serialization;

namespace Assignment_8._2_Symmetrical_Binary_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(2);
            root.left.left = new Node(3);
            root.left.right = new Node(4);
            root.right.left = new Node(4);
            root.right.right = new Node(3);

            Console.WriteLine(IsSymmetrical(root));
        }

        static bool IsSymmetrical(Node root)
        {
            if (root == null)
            {
                return true;
            }

            var treeStack = new Stack<Node>();

            treeStack.Push(root.left);
            treeStack.Push(root.right);

            while (treeStack.Count != 0)
            {
                Node node1 = treeStack.Pop();
                Node node2 = treeStack.Pop();

                if (node1 == null && node2 == null)
                {
                    continue;
                }

                if (node1 == null || node2 == null)
                {
                    return false;
                }

                if (node1.key != node2.key)
                {
                    return false;
                }

                treeStack.Push(node1.left);
                treeStack.Push(node2.right);
                treeStack.Push(node1.right);
                treeStack.Push(node2.left);
            }

            return true;
        }

        public class Node
        {
            public int key;
            public Node? left;
            public Node? right;


            //Constructor
            public Node(int item)
            {
                key = item;
                left = right = null;
            }
        }
    }
}
