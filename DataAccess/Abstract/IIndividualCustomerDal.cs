using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IIndividualCustomerDal : IEntityRepository<IndividualCustomer>
    {
        void AddIndividualCustomer(User user, IndividualCustomer customer);

        void DeleteIndividualCustomer(User user, IndividualCustomer customer);

        void UpdateIndividualCustomer(User user , IndividualCustomer customer);
        List<IndividualCustomerWithUserInfoDto> GetAllIndividualCustomer();
    }

}
