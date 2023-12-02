﻿using System.Reflection;

namespace AoC2023;

internal class Program
{
    private static void Main()
    {
        int start = Environment.TickCount;

        new Day02().Do();
        //RunAll();

        Console.WriteLine($"Time: {Environment.TickCount - start} ms");
    }

    private static void RunAll()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Name[0..3].Equals("Day") && char.IsDigit(t.Name[4]))
            .OrderBy(t => t.Name);
        var defaultCtor = Array.Empty<Type>();
        foreach (var type in types)
        {
            var ctor = type.GetConstructor(defaultCtor);
            if (ctor == null)
                throw new Exception($"No default ctor for {type.Name}");
            var instance = ctor.Invoke(null);
            RunDay((IDay)instance);
        }
    }

    private static void RunDay(IDay day)
    {
        Console.WriteLine(day.GetType().Name);
        day.Do();
        Console.WriteLine();
    }
}