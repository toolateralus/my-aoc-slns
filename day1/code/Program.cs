using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

string[] data = File.ReadAllLines("../input.txt");

//Part1(data);
//Part2(data);
Part2V2(data);

static void Part1(IEnumerable<string> data)
{
    List<int> results = [];

    foreach (string line in data)
    {
        char? lhs = line.FirstOrDefault(char.IsDigit);
        char? rhs = line.LastOrDefault(char.IsDigit);
        results.Add(int.Parse(lhs.ToString() + rhs.ToString()));
    }

    int total = 0;
    
    foreach (int item in results)
        total += item;
    
    Console.WriteLine($"Part 1 Answer : {total}");
}



static void Part2V2(IEnumerable<string> data)
{
    List<string> intermediate = [];
    foreach (var line in data)
    {
        // i wasn't able to figure this out fully alone : my most accurate attempt used slicing, but still failed.
        // the attempt previous to that one was similar to this, but it lost data since it didnt use 'one1one' but just 'one' as the replacement.
        // i found this on reddit.
        intermediate.Add(
            line.Replace("one", "one1one")
            .Replace("two", "two2two")
            .Replace("three", "three3three")
            .Replace("four", "four4four")
            .Replace("five", "five5five")
            .Replace("six", "six6six")
            .Replace("seven", "seven7seven")
            .Replace("eight", "eight8eight")
            .Replace("nine", "nine9nine")
        );
    }
    Part1(intermediate);

}

static void Part2(IEnumerable<string> data)
{
    List<int> results = [];

    Dictionary<string, string> singleDigits = new(){
        {"zero", "0"},
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"},
    };

    foreach (var line in data)
    {
        bool first = false, last = false;
        string sFirst = "", sLast = "";

        char? lhs = line.FirstOrDefault(char.IsDigit);
        char? rhs = line.LastOrDefault(char.IsDigit);

        // this just grabs the first 'one' or 'eight' but we need to parse 'oneight' as '1 8' 
        // -- info gotten from a spoiler on reddit.
        if (lhs is null)
            for (int i = 0; i < line.Length; ++i)
            {
                if (!first && singleDigits.TryGetValue(line[..i], out var value))
                {
                    first = true;
                    sFirst = value;
                    break;
                }
            }

        if (rhs is null)
            for (int i = line.Length; i > 0; --i)
            {
                if (!last && singleDigits.TryGetValue(line[i..], out var value))
                {
                    last = true;
                    sLast = value;
                    break;
                }
            }

        // if we found a 'one' or 'eight' use that, else use the single digit like '1' or '8'
        int digit = int.Parse(first ? sFirst : lhs.ToString() + (last ? sLast : rhs.ToString()));

        results.Add(digit);
    }

    var total = 0;

    foreach (var res in results)
    {
        total += res;
    }

    System.Console.WriteLine($"Part 2 Answer : {total}");
}
