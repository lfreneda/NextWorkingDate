using System;
using FluentAssertions;
using NUnit.Framework;
using NextWorkingDay.HolidayProviders;

namespace NextWorkingDay.Tests
{
    [TestFixture]
    public class BrazilianNonFixedHolidaysTests
    {
        [TestCase(2012, 02, 21)]
        [TestCase(2013, 02, 12)]
        [TestCase(2014, 03, 04)]
        [TestCase(2015, 02, 17)]
        [TestCase(2016, 02, 09)]
        [TestCase(2017, 02, 28)]
        [TestCase(2018, 02, 13)]
        [TestCase(2019, 03, 05)]
        [TestCase(2020, 02, 25)]
        public void GivenAYear_CarnivalDateShouldBeAsExpected(short year, short carnivalMonthExpected, short carnivalDayExpected)
        {
            var carnivalDateExpected = new DateTime(year, carnivalMonthExpected, carnivalDayExpected);
            var nonFixedHolidays = new BrazilianNonFixedHolidays(year);

            nonFixedHolidays.CarnivalDate.Should().Be(carnivalDateExpected);
        }
    }
}