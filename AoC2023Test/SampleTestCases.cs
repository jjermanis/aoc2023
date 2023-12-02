﻿
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

    }
}