using MessagesBusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace MessagesBusinessLogic.Services
{
    public interface IMessageService
    {
        Message GetMessageOfTheDay(int week, DayOfWeek dayOfWeek);
        List<Day> GetMessagesForWeek(int week);
    }
}