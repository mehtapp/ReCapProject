using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CorporateCustomerValidator : AbstractValidator<CorporateCustomer>
    {
        public CorporateCustomerValidator()
        {
            RuleFor(c => c.CompanyName).MinimumLength(2);
            RuleFor(c => c.CompanyName).NotEmpty();
            //RuleFor(c => c.UserId).NotEmpty(); //kullanıcı atamıyor sistem atıyor.
            //RuleFor(u => u.Email).NotEmpty();
            //RuleFor(u => u.Password).NotEmpty();
            //RuleFor(u => u.Password).MinimumLength(6);
            //RuleFor(u => u.UserName).NotEmpty();
            //RuleFor(u => u.UserName).MinimumLength(5);
            //RuleFor(u => u.CurrentUser).SetValidator(new UserValidator());
        }
    }
}
