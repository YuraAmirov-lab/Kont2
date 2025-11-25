using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> queue = new List<int>();

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split();
            int eventType = int.Parse(parts[0]);

            if (eventType == 1)
            {
                int id = int.Parse(parts[1]);
                queue.Add(id);
            }
            else if (eventType == 2)
            {
                if (queue.Count > 0)
                {
                    queue.RemoveAt(0);
                }
            }
            else if (eventType == 3)
            {
                if (queue.Count > 0)
                {
                    queue.RemoveAt(queue.Count - 1);
                }
            }
            else if (eventType == 4)
            {
                int q = int.Parse(parts[1]);
                int index = queue.IndexOf(q);
                Console.WriteLine(index);
            }
            else if (eventType == 5)
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue[0]);
                }
            }
        }
    }
}