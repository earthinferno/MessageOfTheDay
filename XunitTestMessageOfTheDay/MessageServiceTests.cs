using FluentAssertions;
using MessagesBusinessLogic.Data;
using MessagesBusinessLogic.Models;
using MessagesBusinessLogic.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XunitTestMessageOfTheDay
{
    public class MessageServiceTests
    {
        public class MessageServicePositiveTests
        {

            private readonly Mock<IMessages> _mockMessages;

            private readonly MessageService _sut;

            private readonly List<Day> _days;
            private readonly Day _monday;

            private readonly string _mockDayOfWeekMesssageImageURI = "mockDayOfWeekMesssageImageURI";


            public MessageServicePositiveTests()
            {
                _mockMessages = new Mock<IMessages>();

                _monday = new Day { DayOfWeek = DayOfWeek.Monday, Message = new Message { Text = "MockMonday", ImageUri = _mockDayOfWeekMesssageImageURI } };

                _days = new List<Day>
                {
                    _monday,
                    new Day { DayOfWeek = DayOfWeek.Tuesday, Message = new Message { Text = "MockTuesday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Wednesday, Message = new Message { Text = "MockWednesday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Thursday, Message = new Message { Text = "MockThursday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Friday, Message = new Message { Text = "MockFriday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Saturday, Message = new Message { Text = "MockSaturday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Sunday, Message = new Message { Text = "MockSunday, ImageUri = _mockDayOfWeekMesssageImageURI"} },
                };

                var messageData = new List<Week>
                {
                    new Week
                    {
                        Number = 1,
                        Days = null
                    },
                    new Week
                    {
                        Number = 99,
                        Days = _days
                    }
                };
                _mockMessages.Setup(x => x.MessageData).Returns(messageData);

                _sut = new MessageService(_mockMessages.Object);

            }

            [Fact]
            public void WhenWeekDataFound_ThenExpectedDataIsReturned()
            {
                var expected = _days;

                var result = _sut.GetMessagesForWeek(99);
                result.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public void WhenNoWeekDataFound_ThenNullIsReturned()
            {
                var result = _sut.GetMessagesForWeek(-99);
                Assert.Null(result);
            }

            [Fact]
            public void WhenDayDataFound_ThenExpectedDataIsReturned()
            {
                var expected = _monday.Message;

                var result = _sut.GetMessageOfTheDay(99, DayOfWeek.Monday);
                result.Should().BeEquivalentTo(expected); 
            }
        }


        public class MessageServiceNegativeTests
        {
            private readonly Mock<IMessages> _mockMessages;

            private readonly MessageService _sut;

            private string mockExceptionMessage = "No Data Found";
            private readonly string _mockDayOfWeekMesssageImageURI = "mockDayOfWeekMesssageImageURI";

            private readonly List<Day> _days;

            public MessageServiceNegativeTests()
            {
                _mockMessages = new Mock<IMessages>();

                _days = new List<Day>
                {
                    new Day { DayOfWeek = DayOfWeek.Tuesday, Message = new Message { Text = "MockTuesday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Wednesday, Message = new Message { Text = "MockWednesday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Thursday, Message = new Message { Text = "MockThursday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Friday, Message = new Message { Text = "MockFriday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Saturday, Message = new Message { Text = "MockSaturday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                    new Day { DayOfWeek = DayOfWeek.Sunday, Message = new Message { Text = "MockSunday", ImageUri = _mockDayOfWeekMesssageImageURI} },
                };

                var messageData = new List<Week>
                {
                    new Week
                    {
                        Number = 1,
                        Days = null
                    },
                    new Week
                    {
                        Number = 99,
                        Days = _days
                    }
                };
                _mockMessages.Setup(x => x.MessageData).Returns(messageData);

                _sut = new MessageService(_mockMessages.Object);

            }


            [Fact]
            public void WhenNoWeekDataFound_ThenExpectionIsReturned()
            {
                Exception ex = Assert.Throws<Exception>(() => _sut.GetMessageOfTheDay(1, DayOfWeek.Monday));
                Assert.Equal(ex.Message, mockExceptionMessage);
            }


            [Fact]
            public void WhenNoDayDataFound_ThenExpectionIsReturned()
            {
                Exception ex = Assert.Throws<Exception>(() => _sut.GetMessageOfTheDay(99, DayOfWeek.Monday));
                Assert.Equal(ex.Message, mockExceptionMessage);
            }
        }
            
    }
}
