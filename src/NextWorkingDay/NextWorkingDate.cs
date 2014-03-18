using System;
using NextWorkingDay.HolidayProviders;

namespace NextWorkingDay
{
    public class NextWorkingDate : INextWorkingDate
    {
        private readonly IHolidayProvider _holidayProvider;

        public NextWorkingDate(IHolidayProvider holidayProvider)
        {
            _holidayProvider = holidayProvider;
        }

        public DateTime GetNext(DateTime date)
        {
            if (date.DayOfWeek.Equals(DayOfWeek.Sunday)) return GetNext(date.AddDays(1));
            if (date.DayOfWeek.Equals(DayOfWeek.Saturday)) return GetNext(date.AddDays(2));
            if (IsCurrentDateAHoliday(date)) return GetNext(date.AddDays(1));
            return date;
        }

        private bool IsCurrentDateAHoliday(DateTime date) {
            return _holidayProvider.IsHoliday(date);
        }
    }
}
