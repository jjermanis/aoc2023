namespace AoC2023;

public class Day04 : DayBase, IDay
{
    private readonly IList<string> _lines;

    public Day04(string filename)
        => _lines = TextFileStringList(filename);

    public Day04() : this("Day04.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(TotalPoints)}: {TotalPoints()}");
        Console.WriteLine($"{nameof(TotalScratchCards)}: {TotalScratchCards()}");
    }

    public int TotalPoints()
    {
        var result = 0;
        foreach (var line in _lines)
        {
            var nums = line.Split(':')[1].Split('|');
            var winners = ParseNumbers(nums[0]);
            var personal = ParseNumbers(nums[1]);
            var curr = 0;
            foreach (var num in winners)
                if (personal.Contains(num))
                    if (curr == 0)
                        curr = 1;
                    else
                        curr *= 2;
            result += curr;
        }
        return result;
    }

    public int TotalScratchCards()
    {
        var result = 0;
        var copies = new List<int>();
        for (var i = 0; i < _lines.Count; i++)
            copies.Add(1);
        for (var curr = 0; curr < _lines.Count; curr++)
        {
            int currCardCount = copies[curr];
            var nums = _lines[curr].Split(':')[1].Split('|');
            var winners = ParseNumbers(nums[0]);
            var personal = ParseNumbers(nums[1]);
            var currCount = 0;
            foreach (var num in winners)
                if (personal.Contains(num))
                    currCount++;
            for (var i = 1; i <= currCount; i++)
                copies[curr + i] += currCardCount;
            result += currCardCount;
        }
        return result;
    }

    private HashSet<int> ParseNumbers(string raw)
    {
        var result = new HashSet<int>();
        var parsed = raw.Split(null);
        foreach (var num in parsed)
            if (num.Length > 0)
                result.Add(int.Parse(num));
        return result;
    }
}