using MessagesBusinessLogic.Models;
using MessagesBusinessLogic.Services;

namespace MessagesBusinessLogic.Services
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

        public Message GetMessageOfTheDay()
        {
            return _messageService.GetMessageOfTheDay(1, _dayOfWeekService.GetDayOfWeek());
        }
    }
}
