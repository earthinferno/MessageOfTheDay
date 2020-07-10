using MessageOfTheDay.Models;
using System;

namespace MessageOfTheDay.Services
{
    public class MessageOfTheDayService : IMessageOfTheDayService
    {
        private readonly IMessageService _messageService;
        private readonly IDayOfWeekService _dayOfWeekService;

        public MessageOfTheDayService(IMessageService messageService, IDayOfWeekService dayOfWeekService)
        {
            _messageService = messageService;
            _dayOfWeekService = dayOfWeekService;
        }

        public MessageOfTheDayViewModel GetMessageOfTheDay()
        {
            return new MessageOfTheDayViewModel
            {
                Message = _messageService.GetMessageOfTheDay(1, _dayOfWeekService.GetDayOfWeek()).Text
            };
        }
    }
}
