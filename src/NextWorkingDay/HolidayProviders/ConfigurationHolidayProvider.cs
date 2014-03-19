using System;
using System.Configuration;
using NextWorkingDay.Configuration;

namespace NextWorkingDay.HolidayProviders
{
    public class ConfigurationHolidayProvider : IHolidayProvider
    {
        private readonly HolidayConfigurationCollection _holidays = null;

        public ConfigurationHolidayProvider()
        {
            var section = ConfigurationManager.GetSection("nextWorkingDays") as HolidayConfigurationSection;
            if (section == null) throw new ConfigurationErrorsException("Could not get nextWorkingDays configuration section");
            _holidays = section.Instances;
        }

        public bool IsHoliday(DateTime date)
        {
            foreach (HolidayConfigurationElement configurationElement in _holidays)
            {
                if (configurationElement.Day == date.Day && configurationElement.Month == date.Month && configurationElement.Year == date.Year)
                {
                    return true;
                }

                if (configurationElement.Day == date.Day && configurationElement.Month == date.Month && !configurationElement.Year.HasValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
