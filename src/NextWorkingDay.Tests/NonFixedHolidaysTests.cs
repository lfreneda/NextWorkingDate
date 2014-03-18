using System;
using FluentAssertions;
using NUnit.Framework;
using NextWorkingDay.HolidayProviders;

namespace NextWorkingDay.Tests
{
    [TestFixture]
    public class NonFixedHolidaysTests
    {
        [TestCase(2012, 04, 08)]
        [TestCase(2013, 03, 31)]
        [TestCase(2014, 04, 20)]
        [TestCase(2015, 04, 05)]
        [TestCase(2016, 03, 27)]
        [TestCase(2017, 04, 16)]
        [TestCase(2018, 04, 01)]
        [TestCase(2019, 04, 21)]
        [TestCase(2020, 04, 12)]
        [TestCase(2021, 04, 04)]
        [TestCase(2022, 04, 17)]
        [TestCase(2023, 04, 09)]
        [TestCase(2024, 03, 31)]
        public void GivenAYear_EasterDateShouldBeAsExpected(int year, int easterMonthExpected, int easterDayExpected)
        {

            var easterDateExpected = new DateTime(year, easterMonthExpected, easterDayExpected);
            var nonFixedHolidays = new NonFixedHolidays(year);

            nonFixedHolidays.EasterDate.Should().Be(easterDateExpected);
        }

        [TestCase(2012, 06, 07)]
        [TestCase(2013, 05, 30)]
        [TestCase(2014, 06, 19)]
        [TestCase(2015, 06, 04)]
        [TestCase(2016, 05, 26)]
        [TestCase(2017, 06, 15)]
        [TestCase(2018, 05, 31)]
        [TestCase(2019, 06, 20)]
        [TestCase(2020, 06, 11)]
        public void GivenAYear_CorpusChristiDateShouldBeAsExpected(int year, int corpusChristiMonthExpected, int corpusChristiDayExpected)
        {
            var corpusChristiDateExpected = new DateTime(year, corpusChristiMonthExpected, corpusChristiDayExpected);
            var nonFixedHolidays = new NonFixedHolidays(year);

            nonFixedHolidays.CorpusChristiDate.Should().Be(corpusChristiDateExpected);
        }
    }
}