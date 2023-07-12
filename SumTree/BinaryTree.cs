namespace SumTree
{
    internal class BinaryTree
    {
        public Node? Root { get; set; }

        public static bool IsSum(BinaryTree tree)
        {
            var sum = Sum(tree.Root);
            Console.WriteLine($"Sum = {sum}");
            return sum == tree.Root?.Value;
        }

        public static int Sum(Node? node)
        {
            if (node is null) return 0;
            if (node.IsLeaf)
            {
                return node.Value;
            }

            var leftSum = Sum(node.Left);
            var rightSum = Sum(node.Right);

            var sum = leftSum + rightSum;
            Console.WriteLine($"For node {node.Value}, sum is {sum}");
            return sum;
        }

    }
}
