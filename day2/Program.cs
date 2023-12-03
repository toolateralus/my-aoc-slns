using System.Numerics;
using System.Text.RegularExpressions;

var data = File.ReadAllLines("input.txt");
List<Entry> entries = [];

const int rMax = 12;
const int gMax = 13;
const int bMax = 14;

foreach (var line in data) {
    
    var firstSemi = line.IndexOf(':');
    var digits = string.Join("", line[..firstSemi].Where(char.IsDigit));
    var gameId = int.Parse(digits);
    var rest = line[line.IndexOf(':')..];
    var atmpts = rest.Split(';');
    
    var entry = new Entry(gameId);
    
    foreach (var attempt in atmpts) {
        var channels = attempt.Split(',');
        ProcessChannel(channels, entry);
    }
}
int sum = 0;

foreach (var game in entries) {
    foreach (var item in game.rgbOccurences) {
        if (item.X > rMax)
            continue;
        if (item.Y > gMax)
            continue;
        if (item.Z > bMax)
            continue;
    }
        
    sum += game.ID; 
}

System.Console.WriteLine(sum);

void ProcessChannel(string[] channels, Entry entry) {
    int R = 0, G = 0, B = 0;
    
    foreach (var item in channels) {
        var digits = string.Join("", item.Where(char.IsDigit));
        
        if (item.Contains("red")){
            R = int.Parse(digits);
        }
        if (item.Contains("green")){
            G = int.Parse(digits);
        }
        if (item.Contains("blue")) {
            B = int.Parse(digits);
        }
    }
    entry.rgbOccurences.Add(new(R,G,B));
}
class Entry (int ID) {
    public int ID = ID;
    public List<Vector3> rgbOccurences = [];
}
