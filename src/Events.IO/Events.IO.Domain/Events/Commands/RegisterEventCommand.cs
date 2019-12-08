using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Events.Commands
{
    public class RegisterEventCommand : BaseEventCommand
    {
        public RegisterEventCommand(string name, DateTime startDate, DateTime endDate, bool free, decimal price, bool online, string sponsor)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Free = free;
            this.Price = price;
            this.Online = online;
            this.Sponsor = sponsor;
        }

    }
}
