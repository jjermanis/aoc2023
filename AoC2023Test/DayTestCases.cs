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
    }
}