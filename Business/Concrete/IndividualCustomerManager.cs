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


        //[ValidationAspect(typeof(UserValidator))]
        //[ValidationAspect(typeof(IndividualCustomerValidator))]
        public IDataResult<IndividualCustomer> AddIndividualCustomer(IndividualCustomer customer)
        {
            return new SuccessDataResult<IndividualCustomer>(_individualDal.AddIndividualCustomer(customer),Messages.Added);
        }

        public IResult DeleteIndividualCustomer(IndividualCustomer customer)
        {
            _individualDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<IndividualCustomerWithUserInfoDto>> GetAllIndividualCustomer()
        {
            return new SuccessDataResult<List<IndividualCustomerWithUserInfoDto>>
                (_individualDal.GetAllIndividualCustomer(), Messages.Listed);

        }
    }
}
