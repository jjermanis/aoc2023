namespace AoC2023;

public class Day05 : DayBase, IDay
{
    // TODO clean up compiler warnings

    public class Map
    {
        public long DestRange;
        public long SourceRange;
        public long RangeLen;

        public Map(string text)
        {
            var numbers = text.Split(null);
            DestRange = long.Parse(numbers[0]);
            SourceRange = long.Parse(numbers[1]);
            RangeLen = long.Parse(numbers[2]);
        }

        public override string ToString()
        {
            return $"{DestRange} {SourceRange} {RangeLen}";
        }
    }

    private readonly IList<string> _lines;
    private readonly IList<long> _seeds;
    private readonly IList<List<Map>> _maps;

    public Day05(string filename)
    {
        _lines = TextFileStringList(filename);
        (_seeds, _maps) = ParseFile();
    }

    public Day05() : this("Day05.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(LowestLocationBySeed)}: {LowestLocationBySeed()}");
        Console.WriteLine($"{nameof(LowestLocationByRange)}: {LowestLocationByRange()}");
    }

    public long LowestLocationBySeed()
    {
        long result = long.MaxValue;
        foreach (var seed in _seeds)
        {
            var curr = seed;
            var debug = curr.ToString() + ", ";
            foreach (var mapSet in _maps)
            {
                foreach (var map in mapSet)
                {
                    if (curr >= map.SourceRange &&
                        curr < map.SourceRange + map.RangeLen)
                    {
                        curr += (map.DestRange - map.SourceRange);
                        break;
                    }
                }
                debug += curr.ToString() + ", ";
            }
            result = Math.Min(result, curr);
        }
        return result;
    }

    public long LowestLocationByRange()
    {
        // TODO look to optimize this
        var result = 0L;
        while (true)
        {
            var curr = result;
            for (var i = _maps.Count - 1; i >=0; i--)
            {
                var mapSet = _maps[i];
                foreach (var map in mapSet)
                {
                    if (curr >= map.DestRange &&
                        curr < map.DestRange + map.RangeLen)
                    {
                        curr -= (map.DestRange - map.SourceRange);
                        break;
                    }
                }
            }
            for (var s = 0; s < _seeds.Count; s += 2)
            {
                if (curr >= _seeds[s] && curr < _seeds[s] + _seeds[s + 1])
                    return result;
            }
            result++;
        }
    }

    private (IList<long>, IList<List<Map>>) ParseFile()
    {
        var rawSeeds = _lines[0].Split(':')[1].Split(null);
        var seedsResult = new List<long>();
        foreach (var rawSeed in rawSeeds)
            if (rawSeed.Length > 0)
                seedsResult.Add(long.Parse(rawSeed));
        var mapsResult = new List<List<Map>>();
        List<Map> currMaps = null;
        for (int i = 2; i < _lines.Count; i++)
        {
            var curr = _lines[i];
            if (curr.Contains("map:"))
            {
                currMaps = new List<Map>();
                mapsResult.Add(currMaps);
            }
            else if (curr.Length > 5)
            {
                currMaps.Add(new Map(curr));
            }
        }
        return (seedsResult, mapsResult);
    }
}