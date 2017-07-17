using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var regionAndShells = new Dictionary<string, HashSet<int>>();

        var inputLine = Console.ReadLine();

        while (inputLine != "Aggregate")
        {
            var tokens = inputLine.Split(' ');
            var region = tokens[0];
            var shell = int.Parse(tokens[1]);

            if (! regionAndShells.ContainsKey(region))
            {
                regionAndShells.Add(region, new HashSet<int>());
            }

            regionAndShells[region].Add(shell);

            inputLine = Console.ReadLine();
        }

        foreach (var item in regionAndShells)
        {
            var region = item.Key;
            var shells = item.Value;
            var average = shells.Sum() - shells.Average();

            Console.WriteLine($"{region} -> {string.Join(", ", shells)} ({Math.Ceiling(shells.Sum() - shells.Average())})");
        }
    }
}

