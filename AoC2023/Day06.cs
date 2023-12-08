namespace AoC2023;

public class Day06 : DayBase, IDay
{
    private readonly IDictionary<int, int> _records;
    private readonly long _totalTime;
    private readonly long _totalDistance;

    public Day06(string filename)
    {
        var lines = TextFileStringList(filename);
        var times = lines[0].Split(':')[1].Split(null).Where(x => x.Length > 0).ToList();
        var distances = lines[1].Split(':')[1].Split(null).Where(x => x.Length > 0).ToList();
        _records = new Dictionary<int, int>();
        for (var i = 0; i < times.Count; i++)
            _records[int.Parse(times[i])] = int.Parse(distances[i]);
        foreach(var time in times)
        {
            var next = _totalTime.ToString() + time.ToString();
            _totalTime = long.Parse(next);
        }
        foreach (var distance in distances)
        {
            var next = _totalDistance.ToString() + distance.ToString();
            _totalDistance = long.Parse(next);
        }
    }

    public Day06() : this("Day06.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(RecordSettingProduct)}: {RecordSettingProduct()}");
        Console.WriteLine($"{nameof(CombinedRecordCount)}: {CombinedRecordCount()}");
    }

    public int RecordSettingProduct()
    {
        var result = 1;
        foreach (var time in _records.Keys)
        {
            var record = _records[time];
            var start = 1;
            for (start = 1; start < time; start++)
            {
                var len = (time - start) * start;
                if (len > record)
                    break;
            }
            var stop = start;
            for (stop = start; stop < time; stop++)
            {
                var len = (time - stop) * stop;
                if (len <= record)
                    break;
            }
            result *= (stop - start);
        }
        return result;
    }

    public int CombinedRecordCount()
    {
        // TODO Refactor code for Part 1 & 2
        var record = _totalDistance;
        var start = 1;
        for (start = 1; start < _totalTime; start++)
        {
            var len = (_totalTime - start) * start;
            if (len > record)
                break;
        }
        var stop = start;
        for (stop = start; stop < _totalTime; stop++)
        {
            var len = (_totalTime - stop) * stop;
            if (len <= record)
                break;
        }
        return stop - start;
    }
}