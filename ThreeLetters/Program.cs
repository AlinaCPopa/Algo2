using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    class Letter
    {
        public char Character { get; set; }
        public int Count { get; set; }
        public int Max { get; set; }

        public Letter(char character, int max)
        {
            Character = character;
            Count = 0;
            Max = max;
        }
    }


    public string solution(int A, int B)
    {
        var letters = new List<Letter>();
        if (A > B)
        {
            letters.Add(new Letter('a', A));
            letters.Add(new Letter('b', B));
        }
        else
        {
            letters.Add(new Letter('b', B));
            letters.Add(new Letter('a', A));
        }

        var result = new List<char>();
        int difference = Math.Abs(letters[0].Max - letters[1].Max);
        int oneses = 0;
        while (letters[0].Count < letters[0].Max ||
            letters[1].Count < letters[1].Max)
        {
            foreach (var letter in letters)
            {
                AddToResult(result, letter);
                if (letter.Count == letter.Max)
                {
                    continue;
                }

                if (letter == letters[1] &&
                  oneses < difference)
                {
                    oneses++;
                }
                else
                {
                    AddToResult(result, letter);
                    if (letter.Count == letter.Max)
                    {
                        continue;
                    }
                }
            }
        }

        return new string(result.ToArray());
    }

    private static void AddToResult(List<char> result, Letter letter)
    {
        if (letter.Count < letter.Max)
        {
            result.Add(letter.Character);
            letter.Count++;
        }
    }

    public static void Main()
    {
        Solution solution = new Solution();
        var result = solution.solution(99, 95);
        Console.WriteLine(result);
    }
}
