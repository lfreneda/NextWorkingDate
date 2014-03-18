using System;
using System.Configuration;
using FluentAssertions;
using NUnit.Framework;
using NextWorkingDay.Configuration;
using NextWorkingDay.HolidayProviders;

namespace NextWorkingDay.Tests
{
    [TestFixture]
    public class HolidayConfigurationSectionTests
    {
        [Test]
        public void CanRetrieveSectionFromAppConfig()
        {
            var section = (HolidayConfigurationSection)ConfigurationManager.GetSection("nextWorkingDays");
            section.Instances.Count.Should().Be(8);
        }
    }

    [TestFixture]
    public class ConfigurationHolidayProviderTests
    {
        [TestCase(null, 1, 1)]
        [TestCase(null, 4, 21)]
        [TestCase(null, 5, 1)]
        [TestCase(null, 9, 7)]
        [TestCase(null, 10, 12)]
        [TestCase(null, 11, 2)]
        [TestCase(null, 11, 15)]
        [TestCase(null, 12, 25)]
        public void IsHoliday_GivenAHolidayAsConfigured_ShouldReturnTrue(int? expectedYear, int expectedMonth, int expectedDay)
        {
            var year = expectedYear.HasValue ? expectedYear.Value : DateTime.Now.Year;
            var holiday = new DateTime(year, expectedMonth, expectedDay);
            
            var configurationHolidayProvider = new ConfigurationHolidayProvider();

            configurationHolidayProvider.IsHoliday(holiday).Should().BeTrue();
        }
    }
















}