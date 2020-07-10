using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageOfTheDay.Models
{
    public class Day
    {
        public DayOfWeek DayOfWeek { get; set; }
        public Message Message { get; set; }
    }
}
