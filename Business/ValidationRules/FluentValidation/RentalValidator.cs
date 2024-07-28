using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).GreaterThan(0);
            RuleFor(r => r.UserId).GreaterThan(0);
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty();
            //RuleFor(r => r.ReturnDate).Empty();
        
        }

       
    }
}
