using MessageOfTheDay.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageOfTheDay.Controllers
{
    public class MessageOfTheDayController : Controller
    {
        private readonly IMessageOfTheDayService _messageOfTheDayService;

        public MessageOfTheDayController(IMessageOfTheDayService messageOfTheDayService)
        {
            _messageOfTheDayService = messageOfTheDayService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(_messageOfTheDayService.GetMessageOfTheDay());
        }
    }
}