using System.Diagnostics;

namespace SumTree
{
    [DebuggerDisplay("Value = {Value}")]
    internal class Node
    {
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public bool IsLeaf => Left is null && Right is null;

        public Node(int value)
        {
            Value = value;
        }
    }
}
