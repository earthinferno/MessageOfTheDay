using MessageOfTheDay.Models;
namespace MessageOfTheDay.Services
{
    public interface IMessageOfTheDayService
    {
        MessageOfTheDayViewModel GetMessageOfTheDay();
    }
}
