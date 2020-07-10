using MessageOfTheDay.Models;
using System.Collections.Generic;

namespace MessageOfTheDay.Data
{
    public interface IMessages
    {
        List<Week> MessageData { get; }
    }
}