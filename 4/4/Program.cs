using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var left = new LinkedList<int>();
        var right = new LinkedList<int>();

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split();
            string command = parts[0];

            if (command == "+")
            {
                int id = int.Parse(parts[1]);
                right.AddLast(id);
                Balance(left, right);
            }
            else if (command == "*")
            {
                int id = int.Parse(parts[1]);
                if (left.Count == right.Count)
                    left.AddLast(id);
                else
                    right.AddFirst(id);
                Balance(left, right);
            }
            else if (command == "-")
            {
                int id = left.First.Value;
                left.RemoveFirst();
                Console.WriteLine(id);
                Balance(left, right);
            }
        }
    }

    private static void Balance(LinkedList<int> left, LinkedList<int> right)
    {
        if (left.Count < right.Count)
        {
            left.AddLast(right.First.Value);
            right.RemoveFirst();
        }
    }
}