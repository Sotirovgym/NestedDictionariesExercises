using System;
using System.Collections.Generic;
using System.Linq;

class SocialMediaPosts
{
    static void Main()
    {
        var posts = new Dictionary<string, Dictionary<string, List<string>>>();
        var comments = new Dictionary<string, string>();

        var inputLine = Console.ReadLine();

        while (inputLine != "drop the media")
        {
            var tokens = inputLine.Split(' ');
            var currentCommand = tokens[0];
            var postName = tokens[1];

            if (currentCommand == "post")
            {
               
                posts[postName] = new Dictionary<string, List<string>>();
            }
            else if (currentCommand == "like")
            {                          

                if (!posts[postName].ContainsKey("like"))
                {
                    posts[postName]["like"] = new List<string>();
                }

                posts[postName]["like"].Add(currentCommand);
            }
            else if (currentCommand == "dislike")
            {

                if (!posts[postName].ContainsKey("dislike"))
                {
                    posts[postName]["dislike"] = new List<string>();
                }

                posts[postName]["dislike"].Add(currentCommand);
            }
            else if (currentCommand == "comment")
            {
                var writer = tokens[2];
                var lenght = currentCommand.Length + postName.Length + writer.Length + 3;
                var comment = inputLine.Substring(lenght);

                if (!posts.ContainsKey(writer))
                {
                    posts[postName][writer] = new List<string>();
                }

                posts[postName][writer].Add(comment);
            }

            inputLine = Console.ReadLine();
        }

        foreach (var post in posts)
        {
            var likes = 0;
            var dislikes = 0;
            var writers = post.Value;

            foreach (var item in post.Value)
            {
                if (item.Key == "like")
                {
                    likes = item.Value.Count;
                }
                else if (item.Key == "dislike")
                {
                    dislikes = item.Value.Count;
                }
            }

            Console.WriteLine($"Post: {post.Key} | Likes: {likes} | Dislikes: {dislikes}");
            Console.WriteLine("Comments:");

            var noComment = true;

            foreach (var comment in writers)
            {
                if (comment.Key != "like" && comment.Key != "dislike")
                {
                    noComment = false;

                    foreach (var com in comment.Value)
                    {
                        Console.WriteLine($"*  {comment.Key}: {com}");
                    }
                }
            }

            if (noComment)
            {
                Console.WriteLine("None");
            }
        }
    }
}

