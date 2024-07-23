using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CorporateCustomerManager : ICorporateCustomerService
    {
        private readonly ICorporateCustomerDal _corporateCustomerDal;

        public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal)
        {
            _corporateCustomerDal = corporateCustomerDal;
        }

        public IResult AddCorporateCustomer(User user, CorporateCustomer customer)
        {
            _corporateCustomerDal.AddCorporateCustomer(user, customer);
            return new SuccessResult("Kurumsal müşteri eklendi.");
        }
    }
}
