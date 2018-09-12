using System;
using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        StringBuilder retString = new StringBuilder();

        foreach (char ch in nucleotide.ToUpper())
        {
            switch (ch)
            {
                case 'A':
                    retString.Append('U');
                    break;
                case 'C':
                    retString.Append('G');
                    break;
                case 'G':
                    retString.Append('C');
                    break;
                case 'T':
                    retString.Append('A');
                    break;
                default:
                    retString.Append('?');
                    break;
            }
        }

        return retString.ToString();
    }
}