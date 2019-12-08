using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Events.Commands
{
    public class RemoveEventCommand : BaseEventCommand
    {
        public RemoveEventCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
