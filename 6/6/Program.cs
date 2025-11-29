using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split();

        Stack<int> stackA = new Stack<int>();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            stackA.Push(int.Parse(input[i]));
        }

        Stack<int> stackB = new Stack<int>();
        List<string> operations = new List<string>();
        int current = 1; 

        while (current <= n)
        {

            if (stackB.Count > 0 && stackB.Peek() == current)
            {
                stackB.Pop();
                operations.Add("pop");
                current++;
            }
            else if (stackA.Count > 0)
            {
                int element = stackA.Pop();
                stackB.Push(element);
                operations.Add("push");
            }
            else
            {
                Console.WriteLine("impossible");
                return;
            }
        }

        foreach (string op in operations)
        {
            Console.WriteLine(op);
        }
    }
}