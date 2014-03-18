using System;

namespace NextWorkingDay
{
    public class NextWorkingDate : INextWorkingDate
    {
        private readonly IHolidayProvider _holidayProvider;

        public NextWorkingDate()
        {

        }

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
            if (_holidayProvider == null) return false;
            return _holidayProvider.IsHoliday(date);
        }
    }

    public interface IHolidayProvider
    {
        bool IsHoliday(DateTime date);
    }
}
