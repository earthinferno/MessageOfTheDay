using MessagesBusinessLogic.Services;
using System;
using System.Globalization;

namespace MessagesBusinessLogic.Services
{
    public class DayOfWeekService : IDayOfWeekService
    {
        // TODO:test this by injecting an instnace of something returin a DateTime.Now
        public DayOfWeek GetDayOfWeek()
        {
            Calendar localizedCalender = CultureInfo.InvariantCulture.Calendar;
            return localizedCalender.GetDayOfWeek(DateTime.Now);
        }
    }
}
