using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIndividualCustomerService
    {
        IResult AddIndividualCustomer(User user, IndividualCustomer customer);

        IResult DeleteIndividualCustomer(User user, IndividualCustomer customer);
        IDataResult<List<IndividualCustomerWithUserInfoDto>> GetAllIndividualCustomer();
    }
}
