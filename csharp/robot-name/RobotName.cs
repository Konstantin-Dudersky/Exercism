using System;
using System.Collections.Generic;
using System.Text;

public class Robot
{
    private string name = null;
    private Random random = new Random();

    private static List<string> usedNames;

    public Robot()
    {
        name = null;
    }
    static Robot()
    {
        usedNames = new List<string>();
    }

    public string Name
    {
        get
        {
            if (name == null)
            {
                while (true)
                {
                    char[] temp = new char[]{
                        (char) ('A' + random.Next(0, 26)),
                        (char) ('A' + random.Next(0, 26)),
                        (char) ('0' + random.Next(0, 10)),
                        (char) ('0' + random.Next(0, 10)),
                        (char) ('0' + random.Next(0, 10)),
                    };
                    string tempStr = new String(temp);
                    if (usedNames.Contains(tempStr))
                    {
                        continue;
                    }
                    else
                    {
                        name = tempStr;
                        usedNames.Add(name);
                        break;
                    }
                }
            }
            return name;
        }
    }

    public void Reset()
    {
        name = null;
    }

}