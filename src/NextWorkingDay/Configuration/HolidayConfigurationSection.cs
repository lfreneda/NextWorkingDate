using System.Configuration;

namespace NextWorkingDay.Configuration
{
    public class HolidayConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public HolidayConfigurationCollection Instances
        {
            get { return (HolidayConfigurationCollection)this[""]; }
            set { this[""] = value; }
        }
    }
}