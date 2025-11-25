using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> mainStack = new Stack<int>();
        Stack<int> minStack = new Stack<int>();

        List<string> results = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            int t = int.Parse(data[0]);

            if (t == 1)
            {
                int x = int.Parse(data[1]);
                mainStack.Push(x);

                if (minStack.Count == 0 || x <= minStack.Peek())
                {
                    minStack.Push(x);
                }
            }
            else if (t == 2)
            {
                int removed = mainStack.Pop();
                if (removed == minStack.Peek())
                {
                    minStack.Pop();
                }
            }
            else 
            {
                results.Add(minStack.Peek().ToString());
            }
        }

        Console.WriteLine(string.Join("\n", results));
    }
}