using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException();
        }

        char[] firstArray = firstStrand.ToCharArray();
        char[] secondArray = secondStrand.ToCharArray();
        int count = 0;

        for (int i = 0; i < firstStrand.Length; i++)
        {
            if (firstArray[i] != secondArray[i])
                count++;
        }

        return count;

    }
}