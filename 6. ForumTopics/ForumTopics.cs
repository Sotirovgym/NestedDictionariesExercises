using System;
using System.Collections.Generic;
using System.Linq;

class ForumTopics
{
    static void Main()
    {
        var forumTopics = new Dictionary<string, HashSet<string>>();

        var inputLine = Console.ReadLine();

        while (inputLine != "filter")
        {
            var tokens = inputLine.Split(new[] { ' ', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var forums = tokens[0];
            var topics = tokens.Skip(1).ToList();

            if (! forumTopics.ContainsKey(forums))
            {
                forumTopics[forums] = new HashSet<string>();
            }

            for (int i = 0; i < topics.Count; i++)
            {
                forumTopics[forums].Add("#" + topics[i]);
            }
            
            inputLine = Console.ReadLine();
        }

        inputLine = Console.ReadLine();

        var neededTopics = inputLine.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var kvp in forumTopics)
        {
            var forum = kvp.Key;
            var topics = kvp.Value;
            var count = 0;

            foreach (var topic in neededTopics)
            {
                if (topics.Contains("#" + topic))
                {
                    count++;

                    if (count == neededTopics.Length)
                    {
                        Console.WriteLine($"{forum} | {string.Join(", ", topics)}");
                    }
                }
            }       
        }
    }
}

