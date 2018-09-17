using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        return (int)Math.Pow(Enumerable.Range(1, max).Sum(), 2);
    }

    public static int CalculateSumOfSquares(int max)
    {
        return (from i in Enumerable.Range(1, max) select i * i).Sum();
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}