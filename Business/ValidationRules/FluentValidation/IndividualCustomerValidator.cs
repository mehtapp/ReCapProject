using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class IndividualCustomerValidator : AbstractValidator<IndividualCustomer>
    {
        public IndividualCustomerValidator()
        {
            //RuleFor(ic => ic.UserId).NotEmpty(); //kullanıcı atamıyor sistem atıyor.
            //RuleFor(u => u.i.CurrentUser).SetValidator(new UserValidator());
            RuleFor(ic=>ic.FirstName).NotEmpty();
            RuleFor(ic=>ic.FirstName).MinimumLength(2);
            RuleFor(ic => ic.LastName).NotEmpty();
            RuleFor(ic => ic.LastName).MinimumLength(2);
            
        }
    }
}
