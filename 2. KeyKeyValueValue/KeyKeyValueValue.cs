using System;
using System.Collections.Generic;
using System.Linq;

class KeyKeyValueValue
{
    static void Main()
    {
        var inputKey = Console.ReadLine();
        var inputValue = Console.ReadLine();
        var n = int.Parse(Console.ReadLine());

        var result = new Dictionary<string, List<string>>();

        for (int i = 0; i < n; i++)
        {
            var inputLine = Console.ReadLine();

            var tokens = inputLine.Split(new[] { ' ', '>', ';' },StringSplitOptions.RemoveEmptyEntries);
            var key = tokens[0];
            var value = tokens.Skip(1).ToList();

            if (key.Contains(inputKey))
            {
                Console.WriteLine($"{key}:");

                for (int j = 0; j < value.Count; j++)
                {
                    if (value[j].Contains(inputValue))
                    {
                        Console.WriteLine($"-{value[j]}");
                    }
                }
            }
            
        }
    }
}

