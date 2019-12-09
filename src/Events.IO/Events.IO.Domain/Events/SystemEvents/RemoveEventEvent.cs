using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Events.SystemEvents
{
    public class RemoveEventEvent : BaseEvent
    {
        public RemoveEventEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
