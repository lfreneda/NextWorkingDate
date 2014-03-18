using System.Configuration;

namespace NextWorkingDay.Configuration
{
    public class HolidayConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("description", IsRequired = true)]
        public string Description
        {
            get { return (string)base["description"]; }
            set { base["description"] = value; }
        }

        [ConfigurationProperty("year", IsRequired = false, DefaultValue = null)]
        public int? Year
        {
            get { return (int?)base["year"]; }
            set { base["year"] = value; }
        }

        [ConfigurationProperty("month", IsRequired = true)]
        public int Month
        {
            get { return (int)base["month"]; }
            set { base["month"] = value; }
        }

        [ConfigurationProperty("day", IsRequired = true)]
        public int Day
        {
            get { return (int)base["day"]; }
            set { base["day"] = value; }
        }
    }
}
