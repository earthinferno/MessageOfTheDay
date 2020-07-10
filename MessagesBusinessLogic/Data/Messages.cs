using MessagesBusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace MessagesBusinessLogic.Data
{
    public class Messages : IMessages
    {
        public List<Week> MessageData => new List<Week>
        {
            new Week
            {
                Number = 1, Days = new List<Day>
                {
                // Sorry for The Cure lyrics :-) but it's a song about days of the week! Actually I like The Cure but not this song :-(
                    new Day { DayOfWeek = DayOfWeek.Monday, Message = new Message { Text = "I don't care if Monday's blue", ImageUri = "images/monday.jpg" } },
                    new Day { DayOfWeek = DayOfWeek.Tuesday, Message = new Message { Text = "Tuesday's grey...", ImageUri = "images/tuesday.jpg" } },
                    new Day { DayOfWeek = DayOfWeek.Wednesday, Message = new Message { Text = "Tuesday's grey... and Wednesday too", ImageUri = "images/wednesday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Thursday, Message = new Message { Text = "Thursday, I don't care about you", ImageUri = "images/thursday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Friday, Message = new Message { Text = "It's Friday, I'm in love", ImageUri = "images/friday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Saturday, Message = new Message { Text = "Saturday, wait", ImageUri = "images/saturday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Sunday, Message = new Message { Text = "And Sunday always comes too late", ImageUri = "images/sunday.jpg"} },
                }
            },
            new Week
            {
                Number = 2, Days = new List<Day>
                {
                    new Day { DayOfWeek = DayOfWeek.Monday, Message = new Message { Text = "Monday", ImageUri = "images/monday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Tuesday, Message = new Message { Text = "Tuesday", ImageUri = "images/tuesday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Wednesday, Message = new Message { Text = "Wednesday", ImageUri = "images/wednesday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Thursday, Message = new Message { Text = "Thursday", ImageUri = "images/thursday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Friday, Message = new Message { Text = "Friday", ImageUri = "images/friday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Saturday, Message = new Message { Text = "Saturday", ImageUri = "images/saturday.jpg"} },
                    new Day { DayOfWeek = DayOfWeek.Sunday, Message = new Message { Text = "Sunday", ImageUri = "images/sunday.jpg"} },
                }
            }
        };
    }
}
