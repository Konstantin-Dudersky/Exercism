using System;
using System.Collections.Generic;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        HashSet<char> hashSet = new HashSet<char>();

        foreach (char ch in input.ToLower())
        {
            if (Char.IsLetter(ch))
            {
                hashSet.Add(ch);
            }
        }

        return (hashSet.Count == 26);
    }
}
