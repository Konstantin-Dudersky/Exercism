using System;
using System.Collections.Generic;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n)
    {
        return (n > 0 && n <= 64) ? (ulong)Math.Pow(2, n - 1) : throw new ArgumentOutOfRangeException();
    }

    public static ulong Total()
    {
        return (from s in Enumerable.Range(1, 64) select Square(s)).Aggregate((x, y) => x + y);
    }

}