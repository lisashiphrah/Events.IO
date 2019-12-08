using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.IO.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity <T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        #region Properties

        public Guid Id { get; protected set; }

        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }

        #endregion

        #region Methods

        #region Overrides

        /// <summary>
        /// Overrides method to compare entity objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        /// <summary>
        /// Gets unique hash code with a magic number
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        /// <summary>
        /// Overrides ToString for logging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetType().Name + "[Id =  " + this.Id + "]";
        }


        #endregion

        #region Operators

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        #endregion

        #endregion
    }
}
