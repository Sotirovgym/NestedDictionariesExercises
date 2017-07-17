using System;
using System.Collections.Generic;
using System.Linq;

class DictRefAdvanced
{
    static void Main()
    {
        var result = new Dictionary<string, List<int>>();

        var inputLine = Console.ReadLine();

        while (inputLine != "end")
        {
            var tokens = inputLine.Split(new[] { ' ', '-', '>', ',' },StringSplitOptions.RemoveEmptyEntries);
            var key = tokens[0];
            var firstValue = -1;

            if (int.TryParse(tokens[1], out firstValue))
            {
                if (!result.ContainsKey(key))
                {
                    result[key] = new List<int>();
                }

                for (int i = 1; i < tokens.Length; i++)
                {
                    result[key].Add(int.Parse(tokens[i]));
                }
            }
            else
            {
                var otherKey = tokens[1];

                if (result.ContainsKey(otherKey))
                {
                    result[key] = new List<int>(result[otherKey]);
                }
            }

            inputLine = Console.ReadLine();
        }

        foreach (var entry in result)
        {
            Console.WriteLine($"{entry.Key} === {string.Join(", ", entry.Value)}");
        }
    }
}

