using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Core.Commands
{
    public class CommandResponse
    {
        public static CommandResponse OK = new CommandResponse(true);
        public static CommandResponse Fail = new CommandResponse(false);

        public CommandResponse(bool success = false)
        {
            this.Success = success;
        }

        public bool Success { get; private set; }
    }
}
