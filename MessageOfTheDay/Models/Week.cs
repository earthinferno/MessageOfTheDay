using System.Collections.Generic;

namespace MessageOfTheDay.Models
{
    public class Week
    {
        public int Number { get; set; }
        public List<Day> Days { get; set; }
    }
}
