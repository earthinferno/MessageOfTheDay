using FluentAssertions;
using MessageOfTheDay.Models;
using MessageOfTheDay.Services;
using Moq;
using System;
using Xunit;

namespace XunitTestMessageOfTheDay
{
    public class MessageOfTheDayServiceTests
    {
        public class MessageOfTheDayServicePositiveTests
        {
            private readonly Mock<IMessageService> _mockMessageService;
            private readonly Mock<IDayOfWeekService> _mockDayOfWeekService;

            private const string mockDayOfWeekMesssageText = "MockDayOfWeekMesssageText";
            private const string mockDayOfWeekMesssageImageURI = "MockDayOfWeekMesssageImageURI";

            private readonly IMessageOfTheDayService _sut;


            public MessageOfTheDayServicePositiveTests()
            {
                _mockDayOfWeekService = new Mock<IDayOfWeekService>();
                _mockMessageService = new Mock<IMessageService>();

                var message = new Message { Text = mockDayOfWeekMesssageText, ImageUri = mockDayOfWeekMesssageImageURI };

                _mockDayOfWeekService.Setup(x => x.GetDayOfWeek()).Returns(DayOfWeek.Monday);
                _mockMessageService.Setup(x => x.GetMessageOfTheDay(It.Is<int>(x => x == 1), It.IsAny<DayOfWeek>())).Returns(message);

                _sut = new MessageOfTheDayService(_mockMessageService.Object, _mockDayOfWeekService.Object);
            }

            [Fact]
            public void WhenGetMessageOfDayThenExpectedMessageReturned()
            {
                var expected = new MessageOfTheDayViewModel
                {
                    Message = mockDayOfWeekMesssageText,
                    ImageUri = mockDayOfWeekMesssageImageURI,
                };

                var result = _sut.GetMessageOfTheDay();


                result.Should().BeEquivalentTo(expected);
            }
        }

        public class MessageOfTheDayServiceNegativeTests
        {
            internal readonly Mock<IMessageService> _mockMessageService;
            internal readonly Mock<IDayOfWeekService> _mockDayOfWeekService;

            internal const string mockExceptionMessage = "No Data Found";

            internal readonly IMessageOfTheDayService _sut;
            public MessageOfTheDayServiceNegativeTests()
            {
                _mockDayOfWeekService = new Mock<IDayOfWeekService>();
                _mockMessageService = new Mock<IMessageService>();

                _mockDayOfWeekService.Setup(x => x.GetDayOfWeek()).Returns(DayOfWeek.Monday);
                _mockMessageService.Setup(x => x.GetMessageOfTheDay(It.Is<int>(x => x == 1), It.IsAny<DayOfWeek>())).Throws(new Exception(mockExceptionMessage));

                _sut = new MessageOfTheDayService(_mockMessageService.Object, _mockDayOfWeekService.Object);
            }

            [Fact]
            public void WhenGetMessageOfDayResultsInException_ThenExceptionIsRaised()
            {
                Exception ex = Assert.Throws<Exception>(() => _sut.GetMessageOfTheDay());
                Assert.Equal(ex.Message, mockExceptionMessage);
            }
        }
    }
}
