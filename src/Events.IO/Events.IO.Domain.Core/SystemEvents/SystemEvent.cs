using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Core.SystemEvents
{
    public abstract class SystemEvent : Message
    {
        public DateTime Timestamp { get; private set; }

        protected SystemEvent()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
