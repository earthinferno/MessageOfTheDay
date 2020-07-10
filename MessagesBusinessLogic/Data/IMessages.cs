using MessagesBusinessLogic.Models;
using System.Collections.Generic;

namespace MessagesBusinessLogic.Data
{
    public interface IMessages
    {
        List<Week> MessageData { get; }
    }
}