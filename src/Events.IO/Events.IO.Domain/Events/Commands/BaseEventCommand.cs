using Events.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Events.Commands
{
    public abstract class BaseEventCommand : Command
    {
        public Guid Id { get; protected set; }
        public string ShortDescription { get; protected set; }
        public string FullDescription { get; protected set; }
        public string Name { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public bool Free { get; protected set; }
        public decimal Price { get; protected set; }
        public bool Online { get; protected set; }
        public string Sponsor { get; protected set; }
    }
}
