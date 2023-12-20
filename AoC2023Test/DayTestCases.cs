namespace AoC2017Test
{
    public class DayTestCases
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Day01()
        {
            var d = new Day01();
            Assert.Multiple(() =>
            {
                Assert.That(d.NumericSum(), Is.EqualTo(54630));
                Assert.That(d.NumericWithTextSum(), Is.EqualTo(54770));
            });
        }

        [Test]
        public void Day02()
        {
            var d = new Day02();
            Assert.Multiple(() =>
            {
                Assert.That(d.PossibleGameSum(), Is.EqualTo(2632));
                Assert.That(d.MinimumGamePowerSum(), Is.EqualTo(69629));
            });
        }

        [Test]
        public void Day03()
        {
            var d = new Day03();
            Assert.Multiple(() =>
            {
                Assert.That(d.SumPartNumbers(), Is.EqualTo(530849));
                Assert.That(d.SumGearRatios(), Is.EqualTo(84900879));
            });
        }

        [Test]
        public void Day04()
        {
            var d = new Day04();
            Assert.Multiple(() =>
            {
                Assert.That(d.TotalPoints(), Is.EqualTo(19855));
                Assert.That(d.TotalScratchCards(), Is.EqualTo(10378710));
            });
        }

        [Test]
        public void Day05()
        {
            var d = new Day05();
            Assert.Multiple(() =>
            {
                Assert.That(d.LowestLocationBySeed(), Is.EqualTo(251346198));
                Assert.That(d.LowestLocationByRange(), Is.EqualTo(72263011));
            });
        }

        [Test]
        public void Day06()
        {
            var d = new Day06();
            Assert.Multiple(() =>
            {
                Assert.That(d.RecordSettingProduct(), Is.EqualTo(1624896));
                Assert.That(d.CombinedRecordCount(), Is.EqualTo(32583852));
            });
        }

        [Test]
        public void Day07()
        {
            var d = new Day07();
            Assert.Multiple(() =>
            {
                Assert.That(d.TotalWinnings(), Is.EqualTo(245794640));
                Assert.That(d.TotalWinningsWithJokers(), Is.EqualTo(247899149));
            });
        }
    }
}