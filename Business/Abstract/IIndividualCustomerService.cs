﻿using Core.Utilities.Results;
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
        IDataResult<IndividualCustomer> AddIndividualCustomer(IndividualCustomer customer);

        IResult DeleteIndividualCustomer(IndividualCustomer customer);
        IDataResult<List<IndividualCustomerWithUserInfoDto>> GetAllIndividualCustomer();
    }
}
