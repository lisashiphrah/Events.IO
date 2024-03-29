﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Core.SystemEvents
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name; //Command, event, etc
        }
    }
}
