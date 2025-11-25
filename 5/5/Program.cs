using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine().Split();
        Stack<int> stack = new Stack<int>();

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                int right = stack.Pop();
                int left = stack.Pop();
                int result = 0;

                switch (token)
                {
                    case "+":
                        result = left + right;
                        break;
                    case "-":
                        result = left - right;
                        break;
                    case "*":
                        result = left * right;
                        break;
                }

                stack.Push(result);
            }
        }

        Console.WriteLine(stack.Pop());
    }
}