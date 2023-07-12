
using SumTree;


var root = new Node(26)
{
    Left = new Node(10)
    {
        Left = new Node(4),
        Right = new Node(6)
    },
    Right = new Node(3)
    {
        Right = new Node(3)
    }
};
var tree = new BinaryTree
{
    Root = root
};

var isSumTree = BinaryTree.IsSum(tree);
Console.WriteLine(isSumTree);