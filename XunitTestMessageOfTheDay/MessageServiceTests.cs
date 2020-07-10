using FluentAssertions;
using MessageOfTheDay.Data;
using MessageOfTheDay.Models;
using MessageOfTheDay.Services;
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


            public MessageServicePositiveTests()
            {
                _mockMessages = new Mock<IMessages>();

                _monday = new Day { DayOfWeek = DayOfWeek.Monday, Message = new Message { Text = "MockMonday" } };

                _days = new List<Day>
                {
                    _monday,
                    new Day { DayOfWeek = DayOfWeek.Tuesday, Message = new Message { Text = "MockTuesday"} },
                    new Day { DayOfWeek = DayOfWeek.Wednesday, Message = new Message { Text = "MockWednesday"} },
                    new Day { DayOfWeek = DayOfWeek.Thursday, Message = new Message { Text = "MockThursday"} },
                    new Day { DayOfWeek = DayOfWeek.Friday, Message = new Message { Text = "MockFriday"} },
                    new Day { DayOfWeek = DayOfWeek.Saturday, Message = new Message { Text = "MockSaturday"} },
                    new Day { DayOfWeek = DayOfWeek.Sunday, Message = new Message { Text = "MockSunday"} },
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

            private readonly List<Day> _days;

            public MessageServiceNegativeTests()
            {
                _mockMessages = new Mock<IMessages>();

                _days = new List<Day>
                {
                    new Day { DayOfWeek = DayOfWeek.Tuesday, Message = new Message { Text = "MockTuesday"} },
                    new Day { DayOfWeek = DayOfWeek.Wednesday, Message = new Message { Text = "MockWednesday"} },
                    new Day { DayOfWeek = DayOfWeek.Thursday, Message = new Message { Text = "MockThursday"} },
                    new Day { DayOfWeek = DayOfWeek.Friday, Message = new Message { Text = "MockFriday"} },
                    new Day { DayOfWeek = DayOfWeek.Saturday, Message = new Message { Text = "MockSaturday"} },
                    new Day { DayOfWeek = DayOfWeek.Sunday, Message = new Message { Text = "MockSunday"} },
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
