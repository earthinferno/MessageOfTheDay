using MessageOfTheDay.Models;
using MessagesApplicationLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace MessageOfTheDay.Controllers
{
    public class MessageOfTheDayController : Controller
    {
        private readonly IStringLocalizer<MessageOfTheDayController> _localizer;

        private readonly IMessageOfTheDayService _messageOfTheDayService;

        public MessageOfTheDayController(
            IMessageOfTheDayService messageOfTheDayService, 
            IStringLocalizer<MessageOfTheDayController> localizer)
        {
            _messageOfTheDayService = messageOfTheDayService;
            _localizer = localizer;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var message = _messageOfTheDayService.GetMessageOfTheDay();

            return View(new MessageOfTheDayViewModel { ImageUri = message.ImageUri, Message = _localizer[message.Text] });
        }
    }
}