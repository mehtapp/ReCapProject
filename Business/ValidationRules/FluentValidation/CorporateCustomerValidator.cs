using Entities.Concrete;
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
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
