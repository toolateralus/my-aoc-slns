using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

string[] data = File.ReadAllLines("/home/josh/source/AoC 2023/day1/input.txt");

//Part1(data);
Part2(data);

static void Part1(string[] data)
{
    List<int> results = [];
    
    foreach (string line in data)
    {
        NormalNumber(results, line);
    }

    int total = 0;
    
    foreach (int item in results)
    {
        total += item;
    }
    
    Console.WriteLine(total);
}

static void Part2(string[] data) {
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
    
    
    foreach (var line in data) {
        bool first = false, last = false;
        string sFirst = "", sLast = "";
        
        char? lhs = line.FirstOrDefault(char.IsDigit);
        char? rhs = line.LastOrDefault(char.IsDigit);
        
        // this just 
        if (lhs is null)
            for (int i = 0; i < line.Length; ++i) {
                if (!first && singleDigits.TryGetValue(line[..i], out var value)) {
                    first = true;
                    sFirst = value;
                    break;
                }
            }
        
        if (rhs is null)
            for (int i = line.Length; i > 0; --i) {
                if (!last && singleDigits.TryGetValue(line[i..], out var value)) {
                    last = true;
                    sLast = value;
                    break;
                } 
            }
        
        if (lhs is null || rhs is null)
            throw new InvalidDataException(line + " contained no matching nums");
        
        int digit = int.Parse(first ? sFirst : lhs.ToString() + (last ? sLast : rhs.ToString()));
        
        results.Add(digit);
    }
    
    var total = 0;
    
    foreach (var res in results) {
        total += res;
    }
    
    System.Console.WriteLine(total);
}

static void NormalNumber(List<int> results, string line)
{
    char? lhs = line.FirstOrDefault(char.IsDigit);
    char? rhs = line.LastOrDefault(char.IsDigit);
    if (lhs is null || rhs is null)
    {
        throw new InvalidDataException(line + " contained no matching nums");
    }
    
    int digit = int.Parse(lhs.ToString() + rhs.ToString());
    
    results.Add(digit);
}