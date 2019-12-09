using Events.IO.Domain.CommandHandlers;
using Events.IO.Domain.Core.SystemEvents;
using Events.IO.Domain.Events.Commands;
using Events.IO.Domain.Events.Repository;
using Events.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Events.CommandHandlers
{
    public class EventCommandHandler : CommandHandler,
        IHandler<RegisterEventCommand>,
        IHandler<UpdateEventCommand>,
        IHandler<RemoveEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public EventCommandHandler(IEventRepository eventRepository, IUnitOfWork _unitOfWork)
            :base(_unitOfWork)
        {
            _eventRepository = eventRepository;
        }

        public void Handle(RegisterEventCommand message)
        {
            var e = new Event(message.Name, message.StartDate, message.EndDate, message.Free, message.Price, message.Online, message.Sponsor);
            if (!e.IsValid())
            {
                NotifyValidationsErros(e.ValidationResult);
                return;
            }

            _eventRepository.Add(e);

            if (Commit())
            {
                Console.WriteLine("Event registered successfully");
            }
        }

        public void Handle(UpdateEventCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RemoveEventCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
