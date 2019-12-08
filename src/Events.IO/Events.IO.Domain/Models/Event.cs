using Events.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.IO.Domain.Models
{
    public class Event : Entity<Event>
    {
        #region Constructors

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="name">Event name</param>
        /// <param name="startDate">Start date of the event</param>
        /// <param name="endDate">End date of the event</param>
        /// <param name="free">If event is for free</param>
        /// <param name="price">Event's price</param>
        /// <param name="online">If event is online</param>
        /// <param name="companyName">Sponsor company</param>
        public Event(string name, DateTime startDate, DateTime endDate, bool free, decimal price, bool online, string sponsor)
        {
            this.Id = new Guid();

            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Free = free;
            this.Price = price;
            this.Online = online;
            this.Sponsor = sponsor;
            this.ValidationErros = new Dictionary<string, string>();
        }
        #endregion

        #region Properties

        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string FullDescription { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool Free { get; private set; }
        public decimal Price { get; private set; }
        public bool Online { get; private set; }
        public Category Category { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        public Address Address { get; private set; }
        public Organizer Organizer { get; private set; }
        public string Sponsor { get; private set; }
        public Dictionary<string, string> ValidationErros { get; set; }

        #endregion

        #region Methods

        public override bool IsValid()
        {
            this.ValidateEntity();
            return ValidationResult.IsValid;
        }


        #region Validations

        /// <summary>
        /// Validates entities
        /// </summary>
        private void ValidateEntity()
        {
            this.ValidateName();
            this.ValidatePrice();
            this.ValidateDate();
            this.ValidateAddress();
            this.ValidateSponsor();

            this.ValidationResult = Validate(this);
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is madatory")
                .Length(2, 150).WithMessage("Name should be between 2 and 150 characters");
        }

        private void ValidatePrice()
        {
            if(!this.Free)
            {
                RuleFor(c => c.Price)
                    .ExclusiveBetween(1, 50000).WithMessage("Price should be between £1 and £50,000");
            }
            else
            {
                RuleFor(c => c.Price)
                    .ExclusiveBetween(0, 0).When(e => e.Free).WithMessage("Price should be £0 for free events");
            }
        }

        private void ValidateDate()
        {
            RuleFor(c => c.StartDate).GreaterThan(c => c.EndDate).WithMessage("Start date after end date");
            RuleFor(c => c.StartDate).LessThan(DateTime.Now).WithMessage("Start date should not start in the past");
        }

        private void ValidateAddress()
        {
            if (this.Online)
                RuleFor(c => c.Address).Null().When(c => c.Online).WithMessage("Online events cannot have an address");
            else
                RuleFor(c => c.Address).NotNull().When(c => c.Online == false).WithMessage("This event must have an address");
        }

        private void ValidateSponsor()
        {
            RuleFor(c => c.Sponsor)
                .NotEmpty().WithMessage("Event sponsor should be provided")
                .Length(2, 150).WithMessage("Sponsor name should be between 2 and 150 characters");
        }

        #endregion

        #endregion
    }
}
