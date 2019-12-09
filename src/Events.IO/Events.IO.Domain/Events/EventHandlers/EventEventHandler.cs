using Events.IO.Domain.Core.SystemEvents;
using Events.IO.Domain.Events.SystemEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Events.EventHandlers
{
    public class EventEventHandler : IHandler<RegisterEventEvent>, IHandler<UpdateEventEvent>, IHandler<RemoveEventEvent>
    {
        public void Handle(RegisterEventEvent message)
        {
            //do something
        }

        public void Handle(UpdateEventEvent message)
        {
            //do something
        }

        public void Handle(RemoveEventEvent message)
        {
            //do something
        }
    }
}
