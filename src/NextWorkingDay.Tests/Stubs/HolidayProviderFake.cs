using System;
using NextWorkingDay.HolidayProviders;

namespace NextWorkingDay.Tests.Stubs
{
    public class HolidayProviderFake : IHolidayProvider
    {
        private readonly Func<DateTime, bool> _funcIsHoliday;

        public HolidayProviderFake(Func<DateTime, bool> funcIsHoliday)
        {
            _funcIsHoliday = funcIsHoliday;
        }

        public bool IsHoliday(DateTime date)
        {
            return _funcIsHoliday.Invoke(date);
        }
    }
}
