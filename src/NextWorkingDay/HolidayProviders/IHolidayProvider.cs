using System;

namespace NextWorkingDay.HolidayProviders
{
    public interface IHolidayProvider
    {
        bool IsHoliday(DateTime date);
    }
}