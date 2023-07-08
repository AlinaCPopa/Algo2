class Tree
{
    public int x;
    public Tree l;
    public Tree r;
}

class Solution
{
    public int HeightSubtree(Tree tree)
    {
        if (tree == null)
        {
            return -1;
        }
        else
        {
            var heightL = HeightSubtree(tree.l);
            var heightR = HeightSubtree(tree.r);
            return Math.Max(heightL, heightR) + 1;
        }
    }

    public int solution(Tree T)
    {
        var height = HeightSubtree(T);

        return height;
    }
}

class Program
{
    public static void Main()
    {
        var tree = new Tree()
        {
            x = 5,
            l = new Tree()
            {
                x = 3,
                l = new Tree()
                {
                    x = 20,
                    l = new Tree()
                    {
                        x = 6
                    }
                }
            },
            r = new Tree()
            {
                x = 10,
                l = new Tree()
                {
                    x = 1
                },
                r = new Tree()
                {
                    x = 15,
                    l = new Tree()
                    {
                        x = 30,
                        r = new Tree()
                        {
                            x = 9
                        }
                    },
                    r = new Tree()
                    {
                        x = 8
                    }
                }
            }
        };

        var sol = new Solution();
        var test = sol.solution(tree);
    }
}

