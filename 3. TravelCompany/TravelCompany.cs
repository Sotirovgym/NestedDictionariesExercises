using System;
using System.Collections.Generic;
using System.Linq;

class TravelCompany
{
    static void Main()
    {
        var mainDic = new Dictionary<string, Dictionary<string, int>>();

        var input = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);


        while (input[0] != "ready")
        {
            var city = input[0];

            var tokens = input[1].Split(',');


            if (!mainDic.ContainsKey(city))
            {
                mainDic.Add(city, new Dictionary<string, int>());
            }

            for (int i = 0; i < tokens.Length; i++)
            {
                string[] viecleAndQuantity = tokens[i].Split('-');
                string viecle = viecleAndQuantity[0];
                int people = int.Parse(viecleAndQuantity[1]);

                if (!mainDic[city].ContainsKey(viecle))
                {
                    mainDic[city].Add(viecle, people);
                }
                else
                {
                    mainDic[city][viecle] = people;
                }

            }


            input = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }


        input = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (true)
        {
            string city = input[0];

            if (city == "travel")
            {
                break;
            }

            int people = int.Parse(input[1]);

            if (mainDic.ContainsKey(city))
            {
                var sum = 0;
                Dictionary<string, int> finalDic = mainDic[city];
                foreach (var item in finalDic)
                {
                    sum += item.Value;
                }

                sum -= people;

                if (sum >= 0)
                {
                    Console.WriteLine($"{city} -> all {people} accommodated");

                }
                else
                {
                    Console.WriteLine($"{city} -> all except {Math.Abs(sum)} accommodated");

                }
            }

            input = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

