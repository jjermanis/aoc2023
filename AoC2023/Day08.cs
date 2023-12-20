using System.Text.RegularExpressions;

namespace AoC2023;

public class Day08 : DayBase, IDay
{
    private string _instructions;
    private Dictionary<string, (string, string)> _directions;

    public Day08(string filename)
    {
        var lines = TextFileStringList(filename);
        _instructions = lines[0];
        _directions = new Dictionary<string, (string, string)>();
        for (var i=2; i<lines.Count; i++)
        {
            var m = Regex.Match(lines[i],
                @"([A-Z]*) = \(([A-Z]*), ([A-Z]*)\)");
            _directions[m.Groups[1].Value] = (m.Groups[2].Value, m.Groups[3].Value);
        }
    }

    public Day08() : this("Day08.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(Part1)}: {Part1()}");
        Console.WriteLine($"{nameof(Part2)}: {Part2()}");
    }

    public int Part1()
    {
        var result = 0;
        var currInst = 0;
        var currLoc = "AAA";
        while (true)
        {
            currInst = currInst % _instructions.Length;
            if (_instructions[currInst] == 'L')
                currLoc = _directions[currLoc].Item1;
            else
                currLoc = _directions[currLoc].Item2;
            result++;
            if (currLoc == "ZZZ")
                return result;
            currInst++;
        }
    }

    public int Part2()
    {
        return 0;
    }
}