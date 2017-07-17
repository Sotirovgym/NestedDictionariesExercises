using System;
using System.Collections.Generic;
using System.Linq;

class Wardrobe
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var dressColors = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < n; i++)
        {
            var inputLine = Console.ReadLine();

            var tokens = inputLine.Split(new string[] { " -> " },StringSplitOptions.RemoveEmptyEntries);
            var color = tokens[0];
            var clothes = tokens[1].Split(',').ToArray();

            if (!dressColors.ContainsKey(color))
            {
                dressColors.Add(color, new Dictionary<string, int>());
            }

            foreach (var cloth in clothes)
            {
                if (!dressColors[color].ContainsKey(cloth))
                {
                    dressColors[color].Add(cloth, 0);
                }

                dressColors[color][cloth]++;
            }             
        }

        var toSearch = Console.ReadLine().Split(' ');

        foreach (var item in dressColors)
        {
            var color = item.Key;
            var dressData = item.Value;

            Console.WriteLine($"{color} clothes:");

            foreach (var kvp in dressColors[color])
            {
                if (item.Key == toSearch[0] && kvp.Key == toSearch[1])
                {
                    Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}

