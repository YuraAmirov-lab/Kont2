using System;
using System.Collections.Generic;

class Program
{
    class BallGroup
    {
        public int Color;
        public int Count;
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int[] balls = new int[n];
        for (int i = 0; i < n; i++)
        {
            balls[i] = int.Parse(input[i + 1]);
        }

        Stack<BallGroup> stack = new Stack<BallGroup>();
        int totalDestroyed = 0;

        foreach (int ball in balls)
        {
            if (stack.Count == 0 || stack.Peek().Color != ball)
            {

                if (stack.Count > 0 && stack.Peek().Count >= 3)
                {
                    totalDestroyed += stack.Pop().Count;
                }

                if (stack.Count > 0 && stack.Peek().Color == ball)
                {
                    stack.Peek().Count++;
                }
                else
                {
                    stack.Push(new BallGroup { Color = ball, Count = 1 });
                }
            }
            else
            {
                stack.Peek().Count++;
            }
        }

        if (stack.Count > 0 && stack.Peek().Count >= 3)
        {
            totalDestroyed += stack.Pop().Count;
        }

        Console.WriteLine(totalDestroyed);
    }
}