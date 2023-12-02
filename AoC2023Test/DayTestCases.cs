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

    }
}