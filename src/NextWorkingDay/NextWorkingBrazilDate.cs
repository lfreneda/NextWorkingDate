using System;
using NextWorkingDay.HolidayProviders;

namespace NextWorkingDay
{
    public class NextWorkingBrazilDate : NextWorkingDate
    {
        public NextWorkingBrazilDate()
            : base(
                new BrazilianNonFixedHolidays(DateTime.Now.Year),
                new ConfigurationHolidayProvider())
        {

        }
    }
}