using System;

public class DSU
{
    private int[] parent;
    private int[] add;
    private int[] extra;

    public DSU(int n)
    {
        parent = new int[n + 1];
        add = new int[n + 1];
        extra = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
        }
    }

    public int Find(int x)
    {
        if (parent[x] != x)
        {
            int root = Find(parent[x]);
            extra[x] += extra[parent[x]];
            parent[x] = root;
        }
        return parent[x];
    }

    public void Union(int x, int y)
    {
        x = Find(x);
        y = Find(y);
        if (x == y) return;
        parent[x] = y;
        extra[x] = add[x] - add[y];
    }

    public void Add(int x, int v)
    {
        x = Find(x);
        add[x] += v;
    }

    public int Get(int x)
    {
        Find(x);
        return add[parent[x]] + extra[x];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string[] firstLine = Console.ReadLine().Split();
        int n = int.Parse(firstLine[0]);
        int m = int.Parse(firstLine[1]);
        DSU dsu = new DSU(n);

        for (int i = 0; i < m; i++)
        {
            string[] parts = Console.ReadLine().Split();
            string operation = parts[0];
            if (operation == "add")
            {
                int x = int.Parse(parts[1]);
                int v = int.Parse(parts[2]);
                dsu.Add(x, v);
            }
            else if (operation == "join")
            {
                int x = int.Parse(parts[1]);
                int y = int.Parse(parts[2]);
                dsu.Union(x, y);
            }
            else if (operation == "get")
            {
                int x = int.Parse(parts[1]);
                Console.WriteLine(dsu.Get(x));
            }
        }
    }
}