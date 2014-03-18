using System;
using FluentAssertions;
using NUnit.Framework;
using NextWorkingDay.HolidayProviders;

namespace NextWorkingDay.Tests
{
    [TestFixture]
    public class NextWorkingDateWithHolidayProviderTests
    {
        private NextWorkingDate _nextWorkingDate;

        [SetUp]
        public void SetUp()
        {
            _nextWorkingDate = new NextWorkingDate(
                new ConfigurationHolidayProvider(),
                new BrazilianNonFixedHolidays(DateTime.Now.Year));
        }

        [Test]
        public void GetNext_Given20140101_NextWorkingDayShouldBe20120202()
        {
            var expectedWorkingDay = new DateTime(2014, 01, 02);
            _nextWorkingDate.GetNext(new DateTime(2014, 01, 01)).Should().Be(expectedWorkingDay);
        }

        [Test]
        public void GetNext_Given20141225_NextWorkingDayShouldBe20120202()
        {
            var expectedWorkingDay = new DateTime(2014, 12, 26);
            _nextWorkingDate.GetNext(new DateTime(2014, 12, 25)).Should().Be(expectedWorkingDay);
        }
    }
}