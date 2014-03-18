using System;

namespace NextWorkingDay.HolidayProviders
{
    public class BrazilianNonFixedHolidays : NonFixedHolidays
    {
        public DateTime CarnivalDate { get; private set; }

        public BrazilianNonFixedHolidays(int year)
            : base(year)
        {
            CarnivalDate = EasterDate.AddDays(-47);
        }

        public override bool IsHoliday(DateTime date)
        {
            if (CarnivalDate.Date == date.Date) return true;
            return base.IsHoliday(date);
        }
    }
}