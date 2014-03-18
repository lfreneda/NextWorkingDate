using System;

namespace NextWorkingDay.HolidayProviders
{
    public class NonFixedHolidays : IHolidayProvider
    {
        public DateTime EasterDate { get; private set; }
        public DateTime CorpusChristiDate { get; private set; }

        public NonFixedHolidays(int year)
        {
            EasterDate = CalculateEasterDate(year);
            CorpusChristiDate = EasterDate.AddDays(60);
        }

        private static DateTime CalculateEasterDate(int year)
        {
            //http://en.wikipedia.org/wiki/Computus

            var mod = (year % 19) + 1;
            var dayResult = new DateTime();
            switch (mod)
            {
                case 1: dayResult = new DateTime(year, 4, 14, 0, 0, 0, 0); break;
                case 2: dayResult = new DateTime(year, 4, 3, 0, 0, 0, 0); break;
                case 3: dayResult = new DateTime(year, 3, 23, 0, 0, 0, 0); break;
                case 4: dayResult = new DateTime(year, 4, 11, 0, 0, 0, 0); break;
                case 5: dayResult = new DateTime(year, 3, 31, 0, 0, 0, 0); break;
                case 6: dayResult = new DateTime(year, 4, 18, 0, 0, 0, 0); break;
                case 7: dayResult = new DateTime(year, 4, 8, 0, 0, 0, 0); break;
                case 8: dayResult = new DateTime(year, 3, 28, 0, 0, 0, 0); break;
                case 9: dayResult = new DateTime(year, 4, 16, 0, 0, 0, 0); break;
                case 10: dayResult = new DateTime(year, 4, 5, 0, 0, 0, 0); break;
                case 11: dayResult = new DateTime(year, 3, 25, 0, 0, 0, 0); break;
                case 12: dayResult = new DateTime(year, 4, 13, 0, 0, 0, 0); break;
                case 13: dayResult = new DateTime(year, 4, 2, 0, 0, 0, 0); break;
                case 14: dayResult = new DateTime(year, 3, 22, 0, 0, 0, 0); break;
                case 15: dayResult = new DateTime(year, 4, 10, 0, 0, 0, 0); break;
                case 16: dayResult = new DateTime(year, 3, 30, 0, 0, 0, 0); break;
                case 17: dayResult = new DateTime(year, 4, 17, 0, 0, 0, 0); break;
                case 18: dayResult = new DateTime(year, 4, 7, 0, 0, 0, 0); break;
                case 19: dayResult = new DateTime(year, 3, 27, 0, 0, 0, 0); break;
            }

            for (var n = 1; n <= 13; n++)
            {
                dayResult = dayResult.AddDays(1);
                if (dayResult.DayOfWeek == DayOfWeek.Sunday)
                    return new DateTime(year, dayResult.Month, dayResult.Day);
            }

            throw new InvalidOperationException(string.Format("Could not calculate easter for {0}", year));
        }

        public virtual bool IsHoliday(DateTime date)
        {
            return date.Date == EasterDate.Date || date.Date == CorpusChristiDate.Date;
        }
    }
}