namespace AoC2023;

public class Day03 : DayBase, IDay
{
    private struct Number
    {
        public int Value;
        public int DigitCount;
        public int X;
        public int Y;

        public Number(int value, int digitCount, int x, int y)
        {
            Value = value;
            DigitCount = digitCount;
            X = x;
            Y = y;
        }
    }

    private readonly IList<string> _lines;
    private readonly IList<Number> _numbers;
    private readonly HashSet<(int, int)> _symbols;
    private readonly HashSet<(int, int)> _gears;

    public Day03(string filename)
    {
        _lines = TextFileStringList(filename);
        _numbers = new List<Number>();
        _symbols = new HashSet<(int, int)>();
        _gears = new HashSet<(int, int)>();
        ParseFile(_lines);
    }

    public Day03() : this("Day03.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(SumPartNumbers)}: {SumPartNumbers()}");
        Console.WriteLine($"{nameof(SumGearRatios)}: {SumGearRatios()}");
    }

    public int SumPartNumbers()
    {
        var result = 0;
        foreach (var number in _numbers)
            if (NeighborPartLocation(number, _symbols) != null)
                result += number.Value;
        return result;
    }

    public int SumGearRatios()
    {
        var result = 0;
        var gearNeighbors = new Dictionary<(int, int), List<Number>>();
        foreach (var gear in _gears)
            gearNeighbors[(gear.Item1, gear.Item2)] = new List<Number>();
        foreach (var number in _numbers)
        {
            var neighborGear = NeighborPartLocation(number, _gears);
            if (neighborGear != null)
                gearNeighbors[(neighborGear.Value.x, neighborGear.Value.y)].Add(number);
        }
        foreach (var gear in _gears)
            if (gearNeighbors[(gear.Item1, gear.Item2)].Count == 2)
                result += gearNeighbors[(gear.Item1, gear.Item2)][0].Value *
                    gearNeighbors[(gear.Item1, gear.Item2)][1].Value;
        return result;
    }

    private void ParseFile(IList<string> lines)
    {
        for (int y = 0; y < lines.Count; y++)
        {
            var line = lines[y] + '.';
            var currNumber = 0;
            var currStart = -1;
            for (int x = 0; x < line.Length; x++)
            {
                var curr = line[x];
                if (curr >= '0' && curr <= '9')
                {
                    if (currNumber == 0)
                        currStart = x;
                    else
                        currNumber *= 10;
                    currNumber += curr - '0';
                }
                else
                {
                    if (currNumber > 0)
                    {
                        _numbers.Add(new Number(currNumber, x - currStart, currStart, y));
                        currNumber = 0;
                    }
                    if (curr != '.')
                    {
                        _symbols.Add((x, y));
                        if (curr == '*')
                            _gears.Add((x, y));
                    }
                }
            }
        }
    }

    private (int x, int y)? NeighborPartLocation(Number number, HashSet<(int, int)> validSymbols)
    {
        // TODO clean this up, make more concise
        if (validSymbols.Contains((number.X - 1, number.Y)))
            return (number.X - 1, number.Y);
        if (validSymbols.Contains((number.X + number.DigitCount, number.Y)))
            return (number.X + number.DigitCount, number.Y);
        for (int x = number.X - 1; x < number.X + number.DigitCount + 1; x++)
        {
            if (validSymbols.Contains((x, number.Y - 1)))
                return (x, number.Y - 1);
            if (validSymbols.Contains((x, number.Y + 1)))
                return (x, number.Y + 1);
        }
        return null;
    }

}
