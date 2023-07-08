

class Tree
{
    public int x;
    public Tree l;
    public Tree r;
};



class Solution
{
    List<Tree> visited = new List<Tree>();

    List<string> path = new List<string>();
    int maxZigZag = 0;
    int zigZagCounter = 0;

    Tree GetSubtree(Tree tree, string direction)
    {
        if (direction == "L")
            return tree.l;
        else if (direction == "R")
            return tree.r;

        return null;
    }

    bool IsLeaf(Tree tree)
    { return tree.l == null && tree.r == null; }


    string DetermindeDirection(Tree tree)
    {
        string result = string.Empty;
        if (path.Count == 0)
        {
            result = "L";
        }
        else
        {
            // try a turn
            result = path.LastOrDefault() == "L" ? "R" : "L";
        }

        if (!IsValidDirection(tree, result))
        {
            result = ChangeDirection(result);
        }

        return result;
    }

    string ChangeDirection(string direction)
    {
        return direction == "L" ? "R" : "L";
    }

    bool IsValidDirection(Tree tree, string direction)
    {
        if (IsLeaf(tree))
        {
            return false;
        }
        var subtree = GetSubtree(tree, direction);
        if (subtree == null || IsVisited(subtree))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool IsVisited(Tree tree)
    { return visited.Contains(tree); }

    bool WasATurn(string direction)
    {
        var lastDirection = path.LastOrDefault();
        if (lastDirection == null) return false;
        return lastDirection != direction;
    }

    Tree GoUpOneLevel(Tree tree)
    {
        Console.WriteLine($"go up one level. tree = {tree.x}");

        Console.WriteLine("Visited:");
        foreach (var item in visited)
        {
            Console.WriteLine(item.x);
        }

        if (zigZagCounter > 0)
        { zigZagCounter--; }

        if (path.Count > 0)
        {
            var indexOfLastInPath = path.Count - 1;
            path.RemoveAt(indexOfLastInPath);
        }
        Console.WriteLine("Path:");
        foreach (var item in path)
        {
            Console.WriteLine(item);
        }

       return GetParent(tree, visited);

    }

    Tree GetParent(Tree tree, List<Tree> visited)
    {
        var index = visited.IndexOf(tree);

        while (index > 0)
        {
            index--;
            var result = visited[index];
            if (result.l == tree || result.r == tree)
            {
                Console.WriteLine($"Found parent node = {result.x}");
                return result;
            }
        }

        return null;
    }

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


    public int solution(Tree T)
    {
        Tree current = T;

        visited.Add(current);

        while (current != null)
        {
            var direction = DetermindeDirection(current);
            if (IsValidDirection(current, direction))
            {
                current = GetSubtree(current, direction);
                visited.Add(current);
                if (WasATurn(direction))
                {
                    zigZagCounter++;
                }
                path.Add(direction);
            }
            else
            {
                if (IsLeaf(current))
                {
                    if (zigZagCounter > maxZigZag)
                    {
                        maxZigZag = zigZagCounter;
                    }
                    current = GoUpOneLevel(current);

                }
                else if (!IsValidDirection(current, ChangeDirection(direction)))
                {
                    current = GoUpOneLevel(current);
                }
            }
        }


        return maxZigZag;
    }


}
