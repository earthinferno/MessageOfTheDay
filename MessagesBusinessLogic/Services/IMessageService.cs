using MessagesApplicationLogic.Models;
using System;
using System.Collections.Generic;

namespace MessagesApplicationLogic.Services
{
    public interface IMessageService
    {
        Message GetMessageOfTheDay(int week, DayOfWeek dayOfWeek);
        List<Day> GetMessagesForWeek(int week);
    }
}