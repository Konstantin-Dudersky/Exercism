using System;
using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        StringBuilder retString = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            retString.Append(input.Substring(i, 1));
        }

        return retString.ToString();
    }
}