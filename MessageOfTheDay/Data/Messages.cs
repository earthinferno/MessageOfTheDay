using MessageOfTheDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageOfTheDay.Data
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
                    new Day { DayOfWeek = DayOfWeek.Monday, Message = new Message { Text = "I don't care if Monday's blue"} },
                    new Day { DayOfWeek = DayOfWeek.Tuesday, Message = new Message { Text = "Tuesday's grey..."} },
                    new Day { DayOfWeek = DayOfWeek.Wednesday, Message = new Message { Text = "Tuesday's grey... and Wednesday too"} },
                    new Day { DayOfWeek = DayOfWeek.Thursday, Message = new Message { Text = "Thursday, I don't care about you"} },
                    new Day { DayOfWeek = DayOfWeek.Friday, Message = new Message { Text = "It's Friday, I'm in love"} },
                    new Day { DayOfWeek = DayOfWeek.Saturday, Message = new Message { Text = "Saturday, wait"} },
                    new Day { DayOfWeek = DayOfWeek.Sunday, Message = new Message { Text = "And Sunday always comes too late"} },
                }
            },
            new Week
            {
                Number = 2, Days = new List<Day>
                {
                    new Day { DayOfWeek = DayOfWeek.Monday, Message = new Message { Text = "Monday"} },
                    new Day { DayOfWeek = DayOfWeek.Tuesday, Message = new Message { Text = "Tuesday"} },
                    new Day { DayOfWeek = DayOfWeek.Wednesday, Message = new Message { Text = "Wednesday"} },
                    new Day { DayOfWeek = DayOfWeek.Thursday, Message = new Message { Text = "Thursday"} },
                    new Day { DayOfWeek = DayOfWeek.Friday, Message = new Message { Text = "Friday"} },
                    new Day { DayOfWeek = DayOfWeek.Saturday, Message = new Message { Text = "Saturday"} },
                    new Day { DayOfWeek = DayOfWeek.Sunday, Message = new Message { Text = "Sunday"} },
                }
            }
        };
    }
}
