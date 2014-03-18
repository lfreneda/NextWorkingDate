using System;
using FluentAssertions;
using NUnit.Framework;
using NextWorkingDay.Tests.Stubs;

namespace NextWorkingDay.Tests
{
    [TestFixture]
    public class NextWorkingDateWithNoHolidayProviderTests
    {
        private NextWorkingDate _nextWorkingDate;

        [SetUp]
        public void SetUp()
        {
            _nextWorkingDate = new NextWorkingDate();
        }

        [Test]
        public void GetNext_GivenAFriday_NextWorkingDateShouldBeTheSameFriday()
        {
            var friday = new DateTime(2014, 05, 16);
            var expectedWorkingDate = friday;

            var workingDate = _nextWorkingDate.GetNext(friday);

            workingDate.Should().Be(expectedWorkingDate, "Friday (2014-05-16) is a working day");
        }

        [Test]
        public void GetNext_GivenASaturday_NextBusinessDayShouldBeMonday()
        {
            var saturday = new DateTime(2014, 03, 22);
            var expectedWorkingDate = new DateTime(2014, 03, 24);

            var workingDate = _nextWorkingDate.GetNext(saturday);

            workingDate.Should().Be(expectedWorkingDate,
                                    "Next working date after saturday (2014-03-22) should be monday (2014-03-24)");
        }

        [Test]
        public void GetNext_GivenASunday_NextBusinessDayShouldBeMonday()
        {
            var sunday = new DateTime(2014, 03, 30);
            var expectedWorkingDate = new DateTime(2014, 03, 31);

            var workingDate = _nextWorkingDate.GetNext(sunday);

            workingDate.Should().Be(expectedWorkingDate,
                                    "Next working date after sunday (2014-03-30) should be monday (2014-03-31)");
        }
    }
}
