using System.Configuration;

namespace NextWorkingDay.Configuration
{
    public class HolidayConfigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HolidayConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HolidayConfigurationElement)element).Description;
        }
    }
}