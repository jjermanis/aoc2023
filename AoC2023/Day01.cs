namespace AoC2023;

public class Day01 : DayBase, IDay
{
    private readonly List<string> WORD_NUMBERS = new() { 
        "one", "two", "three", "four", "five", 
        "six", "seven", "eight", "nine"
    };

    private readonly IEnumerable<string> _lines;

    public Day01(string filename)
        => _lines = TextFileLines(filename);

    public Day01() : this("Day01.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(NumericSum)}: {NumericSum()}");
        Console.WriteLine($"{nameof(NumericWithTextSum)}: {NumericWithTextSum()}");
    }

    public int NumericSum()
    {
        var result = 0;
        foreach (var line in _lines)
            result += TwoDigitNumber(line);
        return result;
    }

    public int NumericWithTextSum()
    {
        var result = 0;
        foreach (var line in _lines)
            result += TwoDigitNumberWithText(line);
        return result;
    }

    private int TwoDigitNumber(string line)
    {
        var left = 0;
        var right = 0;
        for (var x = 0; x < line.Length; x++)
            if (IsDigit(line[x]))
            {
                left = ConvertDigit(line[x]);
                break;
            }
        for (var x = line.Length-1; x >=0; x--)
            if (IsDigit(line[x]))
            {
                right = ConvertDigit(line[x]);
                break;
            }
        return (10 * left) + right;
    }

    private int TwoDigitNumberWithText(string line)
    {
        var r = 10 * FindLeftDigit(line) + FindRightDigit(line);
        return r;
    }

    private static bool IsDigit(char c)
        => c >= '0' && c <= '9';

    private static int ConvertDigit(char c)
        => c - '0';

    private int FindLeftDigit(string line)
    {
        for (var x = 0; x < line.Length; x++)
            if (IsDigit(line[x]))
                return ConvertDigit(line[x]);
            else
                 for (var d = 0; d < WORD_NUMBERS.Count; d++)
                    if (x + WORD_NUMBERS[d].Length < line.Length)
                        if (line.Substring(x, WORD_NUMBERS[d].Length) == WORD_NUMBERS[d])
                            return d + 1;
        throw new Exception("No digit found");
    }

    private int FindRightDigit(string line)
    {
        for (var x = line.Length - 1; x >= 0; x--)
            if (IsDigit(line[x]))
                return ConvertDigit(line[x]);
            else
                for (var d = 0; d < WORD_NUMBERS.Count; d++)
                {
                    var currLen = WORD_NUMBERS[d].Length;

                    if (x - currLen >= 0)
                        if (line.Substring(x - currLen + 1, currLen) == WORD_NUMBERS[d])
                            return d + 1;
                }
        throw new Exception("No digit found");
    }
}