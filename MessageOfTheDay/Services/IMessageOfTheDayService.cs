using MessageOfTheDay.Models;
namespace MessageOfTheDay.Services
{
    public interface IMessageOfTheDayService
    {
        Message GetMessageOfTheDay();
    }
}
