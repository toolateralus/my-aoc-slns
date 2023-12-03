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
    
    foreach (var attempt in atmpts) {
        var channels = attempt.Split(',');
        entries.Add(ProcessChannel(gameId, channels));
    }
}
int sum = 0;

foreach (var item in entries) {
    
    if (item.rgbOccurences.X > rMax)
        continue;
    if (item.rgbOccurences.Y > gMax)
        continue;
    if (item.rgbOccurences.Z > bMax)
        continue;
        
    sum += item.ID; 
}

System.Console.WriteLine(sum);

Entry ProcessChannel(int gameId, string[] channels) {
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
    
    return new (gameId, R, G, B);
}
class Entry (int ID, int R, int G, int B) {
    public int ID = ID;
    public Vector3 rgbOccurences = new(R,G,B);
}
