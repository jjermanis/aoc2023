
namespace AoC2017Test
{
    internal class SampleTestCases
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day01()
        {
            var t1 = new Day01("Day01Test01.txt");
            Assert.That(t1.NumericSum(), Is.EqualTo(142));

            var t2 = new Day01("Day01Test02.txt");
            Assert.That(t2.NumericWithTextSum(), Is.EqualTo(281));
        }

        [Test]
        public void Day02()
        {
            var d = new Day02("Day02Test01.txt");
            Assert.Multiple(() =>
            {
                Assert.That(d.PossibleGameSum(), Is.EqualTo(8));
                Assert.That(d.MinimumGamePowerSum(), Is.EqualTo(2286));
            });
        }

        [Test]
        public void Day03()
        {
            var d = new Day03("Day03Test01.txt");
            Assert.Multiple(() =>
            {
                Assert.That(d.SumPartNumbers(), Is.EqualTo(4361));
                Assert.That(d.SumGearRatios(), Is.EqualTo(467835));
            });
        }

        [Test]
        public void Day04()
        {
            var d = new Day04("Day04Test01.txt");
            Assert.Multiple(() =>
            {
                Assert.That(d.TotalPoints(), Is.EqualTo(13));
                Assert.That(d.TotalScratchCards(), Is.EqualTo(30));
            });
        }

        [Test]
        public void Day05()
        {
            var d = new Day05("Day05Test01.txt");
            Assert.Multiple(() =>
            {
                Assert.That(d.LowestLocationBySeed(), Is.EqualTo(35));
                Assert.That(d.LowestLocationByRange(), Is.EqualTo(46));
            });
        }

        [Test]
        public void Day06()
        {
            var d = new Day06("Day06Test01.txt");
            Assert.Multiple(() =>
            {
                Assert.That(d.RecordSettingProduct(), Is.EqualTo(288));
                Assert.That(d.CombinedRecordCount(), Is.EqualTo(71503));
            });
        }

        [Test]
        public void Day07()
        {
            var d = new Day07("Day07Test01.txt");
            Assert.Multiple(() =>
            {
                Assert.That(d.TotalWinnings(), Is.EqualTo(6440));
                Assert.That(d.TotalWinningsWithJokers(), Is.EqualTo(5905));
            });
        }
    }
}
