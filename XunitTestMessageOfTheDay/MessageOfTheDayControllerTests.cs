using FluentAssertions;
using MessageOfTheDay.Controllers;
using MessageOfTheDay.Models;
using MessagesApplicationLogic.Models;
using MessagesApplicationLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace XunitTestMessageOfTheDay
{
    public class MessageOfTheDayControllerTests
    {
        public static Message mondayMessage = new Message { Text = "I don't care if Monday's blue" },
            tuesdayMessage = new Message { Text = "Tuesday's grey..." },
            wednesdayMessage = new Message { Text = "Tuesday's grey... and Wednesday too" },
            thursdayMessage = new Message { Text = "Thursday, I don't care about you" },
            fridayMessage = new Message { Text = "It's Friday, I'm in love" },
            saturdayMessage = new Message { Text = "Saturday, wait" },
            sundayMessage = new Message { Text = "And Sunday always comes too late" };

        public class MessageOfTheDayControllerFrenchTests
        {
            private readonly IStringLocalizer<MessageOfTheDayController> _localizer;

            private readonly Mock<IMessageOfTheDayService> _mockMessageOfTheDayService;

            private MessageOfTheDayController _sut;

            public string mondayFrenchMessage = "Je m'en fiche si le lundi est bleu",
                tuesdayFrenchMessage = "Le gris de mardi ...",
                wednesdayFrenchMessage = "Mardi gris ... et mercredi aussi",
                thursdayFrenchMessage = "Le gris de mardi ...",
                fridayFrenchMessage = "C'est vendredi je suis amoureux",
                saturdayFrenchMessage = "Samedi, attends",
                sundayFrenchMessage = "Et le dimanche arrive toujours trop tard";



            public MessageOfTheDayControllerFrenchTests()
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");

                var options = Options.Create(new LocalizationOptions { ResourcesPath = "Resources" });
                var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
                _localizer = new StringLocalizer<MessageOfTheDayController>(factory);

                _mockMessageOfTheDayService = new Mock<IMessageOfTheDayService>();

                _sut = new MessageOfTheDayController(_mockMessageOfTheDayService.Object, _localizer);

            }

            [Fact]
            public void WhenMondayThenMondayFrenchMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = mondayFrenchMessage };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(mondayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenTuesdayThenTuesdayFrenchMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = tuesdayFrenchMessage };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(tuesdayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenWednesdayThenWednesdayFrenchMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = wednesdayFrenchMessage };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(wednesdayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenThursdayThenThursdayFrenchMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = thursdayFrenchMessage };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(thursdayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenFridayThenFridayFrenchMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = fridayFrenchMessage };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(fridayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenSaturdayThenSaturdayFrenchMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = saturdayFrenchMessage };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(saturdayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenSundayThenSundayFrenchMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = sundayFrenchMessage };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(sundayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

        }

        public class MessageOfTheDayControllerEnglishTests
        {

            private readonly IStringLocalizer<MessageOfTheDayController> _localizer;

            private readonly Mock<IMessageOfTheDayService> _mockMessageOfTheDayService;

            private MessageOfTheDayController _sut;

            public MessageOfTheDayControllerEnglishTests ()
            {
                var options = Options.Create(new LocalizationOptions { ResourcesPath = "Resources" });
                var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
                _localizer = new StringLocalizer<MessageOfTheDayController>(factory);

                _mockMessageOfTheDayService = new Mock<IMessageOfTheDayService>();

                _sut = new MessageOfTheDayController(_mockMessageOfTheDayService.Object, _localizer);
            }

            [Fact]
            public void WhenMondayThenModayEnglishMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = mondayMessage.Text };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(mondayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenTuesdayThenTuesdayEnglishMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = tuesdayMessage.Text };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(tuesdayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenWednesdayThenWednesdayEnglishMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = wednesdayMessage.Text };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(wednesdayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenThursdayThenThursdayEnglishMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = thursdayMessage.Text };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(thursdayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenFridayThenTuesdayFridayMessageIsreturned()
            {
                var expected = new MessageOfTheDayViewModel { Message = fridayMessage.Text };
                _mockMessageOfTheDayService.Setup(x => x.GetMessageOfTheDay()).Returns(fridayMessage);

                var response = _sut.Index() as ViewResult;

                response.Model.Should().BeEquivalentTo(expected);
            }


        }
    }
}
