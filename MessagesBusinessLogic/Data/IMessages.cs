using MessagesApplicationLogic.Models;
using System.Collections.Generic;

namespace MessagesApplicationLogic.Data
{
    public interface IMessages
    {
        List<Week> MessageData { get; }
    }
}