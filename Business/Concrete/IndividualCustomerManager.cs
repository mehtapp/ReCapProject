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
    public class IndividualCustomerManager : IIndividualCustomerService
    {
        private readonly IIndividualCustomerDal _individualDal;

        public IndividualCustomerManager(IIndividualCustomerDal individualDal)
        {
            _individualDal = individualDal;
        }


        [ValidationAspect(typeof(UserValidator))]
        [ValidationAspect(typeof(IndividualCustomerValidator))]
        public IResult AddIndividualCustomer(User user, IndividualCustomer customer)
        {
            _individualDal.AddIndividualCustomer(user, customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteIndividualCustomer(User user, IndividualCustomer customer)
        {
            _individualDal.DeleteIndividualCustomer(user, customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<IndividualCustomerWithUserInfoDto>> GetAllIndividualCustomer()
        {
            return new SuccessDataResult<List<IndividualCustomerWithUserInfoDto>>
                (_individualDal.GetAllIndividualCustomer(), Messages.Listed);

        }
    }
}
