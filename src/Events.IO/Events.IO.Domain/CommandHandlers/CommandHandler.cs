using Events.IO.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        protected CommandHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        protected void NotifyValidationsErros(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }

        protected bool Commit()
        {
            //TODO: Check any invalid business validation before commit

            var commandResponse = unitOfWork.Commit();
            if (commandResponse.Success) return true;

            Console.WriteLine("Error - Events.IO.Domain.CommandHandlers.CommandHandler.Commit");
            return false;
        }
    }
}
