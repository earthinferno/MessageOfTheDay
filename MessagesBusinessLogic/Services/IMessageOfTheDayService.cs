using MessagesBusinessLogic.Models;
namespace MessagesBusinessLogic.Services
{
    public interface IMessageOfTheDayService
    {
        Message GetMessageOfTheDay();
    }
}
