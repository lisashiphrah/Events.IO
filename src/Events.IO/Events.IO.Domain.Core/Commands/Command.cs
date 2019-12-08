using Events.IO.Domain.Core.SystemEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
