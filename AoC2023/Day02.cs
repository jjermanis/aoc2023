namespace AoC2023;

public class Day02 : DayBase, IDay
{
    private readonly IDictionary<string, int> LIMITS = new Dictionary<string, int>()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 },
    };

    private readonly IEnumerable<string> _lines;

    public Day02(string filename)
        => _lines = TextFileLines(filename);

    public Day02() : this("Day02.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(PossibleGameSum)}: {PossibleGameSum()}");
        Console.WriteLine($"{nameof(MinimumGamePowerSum)}: {MinimumGamePowerSum()}");
    }

    public int PossibleGameSum()
    {
        var result = 0;
        var id = 0;
        foreach (var line in _lines)
        {
            id++;
            var curr = ParseGame(line);
            if (IsValid(curr))
                result += id;
        }
        return result;
    }

    public int MinimumGamePowerSum()
    {
        var result = 0;
        foreach (var line in _lines)
        {
            var curr = ParseGame(line);
            result += MinimumSizeProduct(curr);
        }
        return result;
    }

    private static List<Dictionary<string, int>> ParseGame(string game)
    {
        var result = new List<Dictionary<string, int>>();
        var fullDesc = game.Split(':')[1];
        var rounds = fullDesc.Split(';');
        foreach (var round in rounds)
        {
            var currRound = new Dictionary<string, int>();
            var cubeSets = round.Split(',');
            foreach (var cubeSet in cubeSets)
            {
                var currSet = cubeSet.Trim().Split(' ');
                currRound[currSet[1]] = int.Parse(currSet[0]);
            }
            result.Add(currRound);
        }
        return result;
    }

    private bool IsValid(List<Dictionary<string, int>> game)
    {
        foreach (var round in game)
            foreach (var set in round)
                if (set.Value > LIMITS[set.Key])
                    return false;

        return true;
    }

    private static int MinimumSizeProduct(List<Dictionary<string, int>> game)
    {
        var minSize = new Dictionary<string, int>()
        {
            { "red", 0 },
            { "green", 0 },
            { "blue", 0 },
        };
        foreach (var round in game)
            foreach (var set in round)
                if (set.Value > minSize[set.Key])
                    minSize[set.Key] = set.Value;
        return minSize["red"] * minSize["green"] * minSize["blue"];
    }
}