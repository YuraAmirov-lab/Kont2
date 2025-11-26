using System;

public class DSURank
{
    private int[] parent;
    private int[] rank;
    private int[] min;
    private int[] max;
    private int[] size;

    public DSURank(int n)
    {
        parent = new int[n + 1];
        rank = new int[n + 1];
        min = new int[n + 1];
        max = new int[n + 1];
        size = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
            rank[i] = 0;
            min[i] = i;
            max[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);
        return parent[x];
    }

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY)
            return;

        if (rank[rootX] < rank[rootY])
        {
            parent[rootX] = rootY;
            UpdateSetInfo(rootY, rootX);
        }
        else if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
            UpdateSetInfo(rootX, rootY);
        }
        else
        {
            parent[rootY] = rootX;
            rank[rootX]++;
            UpdateSetInfo(rootX, rootY);
        }
    }

    private void UpdateSetInfo(int rootA, int rootB)
    {
        min[rootA] = Math.Min(min[rootA], min[rootB]);
        max[rootA] = Math.Max(max[rootA], max[rootB]);
        size[rootA] += size[rootB];
    }

    public void GetInfo(int x)
    {
        int root = Find(x);
        Console.WriteLine($"{min[root]} {max[root]} {size[root]}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        DSURank dsu = new DSURank(n);

        string line;
        while ((line = Console.ReadLine()) != null && line != "")
        {
            string[] parts = line.Split();
            if (parts.Length == 0) continue;

            string operation = parts[0];

            if (operation == "union")
            {
                if (parts.Length >= 3)
                {
                    int x = int.Parse(parts[1]);
                    int y = int.Parse(parts[2]);
                    dsu.Union(x, y);
                }
            }
            else if (operation == "get")
            {
                if (parts.Length >= 2)
                {
                    int x = int.Parse(parts[1]);
                    dsu.GetInfo(x);
                }
            }
        }
    }
}