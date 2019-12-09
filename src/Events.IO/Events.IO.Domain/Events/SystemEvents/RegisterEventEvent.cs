using Events.IO.Domain.Core.SystemEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Events.SystemEvents
{
    public class RegisterEventEvent : BaseEvent
    {
        public RegisterEventEvent(
            Guid id,
            string name,
            string shortDesc,
            string longDesc,
            DateTime startDate,
            DateTime endDate,
            bool free,
            decimal price,
            bool online,
            string sponsor)
        {
            this.Id = id;
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Free = free;
            this.Price = price;
            this.Online = online;
            this.Sponsor = sponsor;

            AggregateId = id;
        }
    }
}
