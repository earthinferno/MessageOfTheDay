using MessagesApplicationLogic.Models;

namespace MessagesApplicationLogic.Services
{
    public interface IMessageOfTheDayService
    {
        Message GetMessageOfTheDay();
    }
}
