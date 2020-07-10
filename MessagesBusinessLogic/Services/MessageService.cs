using MessagesBusinessLogic.Data;
using MessagesBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagesBusinessLogic.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessages _messages;

        public MessageService(IMessages messages)
        {
            _messages = messages;
        }

        public List<Day> GetMessagesForWeek(int weekNum)
        {
            return _messages
                .MessageData
                .Where(week => week.Number == weekNum)
                .FirstOrDefault()?
                .Days;
        }

        public Message GetMessageOfTheDay(int week, DayOfWeek dayOfWeek)
        {
            var message = GetMessagesForWeek(week)?
                .Where(day => day.DayOfWeek == dayOfWeek)
                .FirstOrDefault()?
                .Message;

            return message?.Text != null 
                ? message : 
                throw new Exception("No Data Found");
       }
    }
}
