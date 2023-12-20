namespace AoC2023;

public class Day07 : DayBase, IDay
{
    // TODO severance refactoring needed

    public enum HandType
    {
        FiveKind = 7,
        FourKind = 6,
        FullHouse = 5,
        ThreeKind = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1,
    }

    public class Hand
    {
        public HandType Type;
        public string Cards;
        public int Bid;

        public Hand(string line, bool isJacksWild)
        {
            var tokes = line.Split();
            Cards = tokes[0];
            Bid = int.Parse(tokes[1]);

            var dist = CardDistribution(Cards);
            if (!isJacksWild)
                Type = CalcHandType(dist);
            else
            {
                var jCount = dist['J'];
                if (jCount == 0)
                    Type = CalcHandType(dist);
                else if (jCount == 1)
                    Type = CalcHandTypeOneJ(dist);
                else if (jCount == 2)
                    Type = CalcHandTypeTwoJ(dist);
                else if (jCount == 3)
                    Type = CalcHandTypeThreeJ(dist);
                else
                    Type = HandType.FiveKind;
            }
        }

        private Dictionary<char, int> CardDistribution(string cards)
        {
            var counts = new Dictionary<char, int>();
            for (char x = '2'; x <= '9'; x++)
                counts[x] = 0;
            counts['A'] = 0;
            counts['K'] = 0;
            counts['Q'] = 0;
            counts['J'] = 0;
            counts['T'] = 0;

            foreach (char ch in cards)
                counts[ch]++;
            return counts;
        }

        private HandType CalcHandType(Dictionary<char, int> counts)
        {
            foreach (var val in counts.Values)
                if (val == 5)
                    return HandType.FiveKind;
            foreach (var val in counts.Values)
                if (val == 4)
                    return HandType.FourKind;
            foreach (var val in counts.Values)
                if (val == 3)
                {
                    foreach (var val2 in counts.Values)
                        if (val2 == 2)
                            return HandType.FullHouse;
                    return HandType.ThreeKind;
                }
            var pairs = 0;
            foreach (var val in counts.Values)
                if (val == 2)
                    pairs++;
            if (pairs == 2)
                return HandType.TwoPair;
            if (pairs == 1)
                return HandType.OnePair;

            return HandType.HighCard;
        }

        private HandType CalcHandTypeOneJ(Dictionary<char, int> counts)
        {
            foreach (var val in counts.Values)
                if (val >= 4)
                    return HandType.FiveKind;
            foreach (var val in counts.Values)
                if (val == 3)
                    return HandType.FourKind;
            var pairs = 0;
            foreach (var val in counts.Values)
                if (val == 2)
                    pairs++;
            if (pairs == 2)
                return HandType.FullHouse;
            if (pairs == 1)
                return HandType.ThreeKind;

            return HandType.OnePair;
        }

        private HandType CalcHandTypeTwoJ(Dictionary<char, int> counts)
        {
            foreach (var val in counts.Values)
                if (val >= 3)
                    return HandType.FiveKind;
            foreach (var car in counts.Keys)
                if (car != 'J' && counts[car] == 2)
                    return HandType.FourKind;
            return HandType.ThreeKind;
        }

        private HandType CalcHandTypeThreeJ(Dictionary<char, int> counts)
        {
            foreach (var val in counts.Values)
                if (val == 2)
                    return HandType.FiveKind;
            return HandType.FourKind;
        }
    }

    private readonly IEnumerable<string> _lines;

    public Day07(string filename)
        => _lines = TextFileLines(filename);

    public Day07() : this("Day07.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(TotalWinnings)}: {TotalWinnings()}");
        Console.WriteLine($"{nameof(TotalWinningsWithJokers)}: {TotalWinningsWithJokers()}");
    }

    public long TotalWinnings()
    {
        var hands = new List<Hand>();
        foreach (var line in _lines)
            hands.Add(new Hand(line, false));
        hands.Sort(CompareHands);

        var result = 0L;
        for (var x = 0; x < hands.Count; x++)
            result += (x + 1) * hands[x].Bid;
        return result;
    }

    public long TotalWinningsWithJokers()
    {
        var hands = new List<Hand>();
        foreach (var line in _lines)
            hands.Add(new Hand(line, true));
        hands.Sort(CompareHandsJWild);

        var result = 0L;
        for (var x = 0; x < hands.Count; x++)
            result += (x + 1) * hands[x].Bid;
        return result;
    }

    private static int CompareHands(Hand x, Hand y)
    {
        if (x.Type != y.Type)
            return (int)x.Type - (int)y.Type;
        for (int i = 0; i<5; i++)
            if (x.Cards[i] != y.Cards[i])
            {
                if (x.Cards[i] == 'A')
                    return 1;
                if (y.Cards[i] == 'A')
                    return -1;
                if (x.Cards[i] == 'K')
                    return 1;
                if (y.Cards[i] == 'K')
                    return -1;
                if (x.Cards[i] == 'Q')
                    return 1;
                if (y.Cards[i] == 'Q')
                    return -1;
                if (x.Cards[i] == 'J')
                    return 1;
                if (y.Cards[i] == 'J')
                    return -1;
                if (x.Cards[i] == 'T')
                    return 1;
                if (y.Cards[i] == 'T')
                    return -1;
                return (int)x.Cards[i] - (int)y.Cards[i];
            }
        return 0;
    }

    private static int CompareHandsJWild(Hand x, Hand y)
    {
        if (x.Type != y.Type)
            return (int)x.Type - (int)y.Type;
        for (int i = 0; i < 5; i++)
            if (x.Cards[i] != y.Cards[i])
            {
                if (x.Cards[i] == 'A')
                    return 1;
                if (y.Cards[i] == 'A')
                    return -1;
                if (x.Cards[i] == 'K')
                    return 1;
                if (y.Cards[i] == 'K')
                    return -1;
                if (x.Cards[i] == 'Q')
                    return 1;
                if (y.Cards[i] == 'Q')
                    return -1;
                if (x.Cards[i] == 'T')
                    return 1;
                if (y.Cards[i] == 'T')
                    return -1;
                if (x.Cards[i] == 'J')
                    return -1;
                if (y.Cards[i] == 'J')
                    return 1;
                return (int)x.Cards[i] - (int)y.Cards[i];
            }
        return 0;
    }
}