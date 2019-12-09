using Events.IO.Domain.Core.Commands;
using Events.IO.Domain.Core.SystemEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;

        void RaiseEvent<T>(T theEvent) where T : SystemEvent;
    }
}
