using Azure.Core;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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


        [ValidationAspect(typeof(UserValidator))]
        [ValidationAspect(typeof(CorporateCustomerValidator))]
        public IResult AddCorporateCustomer(User user,CorporateCustomer customer)
        {

            //User user = new User
            //{
            //    UserName = customer.UserName,
            //    Email = customer.Email,
            //    Password = customer.Password
            //};
            //CorporateCustomer corporateCustomer = new CorporateCustomer
            //{
            //    CompanyName = customer.CorporateName
            //};
            _corporateCustomerDal.AddCorporateCustomer(user, customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteCorporateCustomer(User user, CorporateCustomer customer)
        {
            _corporateCustomerDal.DeleteCorporateCustomer(user, customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CorporateCustomerWithUserInfoDto>> GetAllCorporateCustomer()
        {
            return new SuccessDataResult<List<CorporateCustomerWithUserInfoDto>>(_corporateCustomerDal.GetAllCorporateCustomer(), Messages.Listed);
        }
    }
}
