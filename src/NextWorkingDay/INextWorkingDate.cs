using System;

namespace NextWorkingDay
{
    public interface INextWorkingDate
    {
        DateTime GetNext(DateTime after);
    }
}