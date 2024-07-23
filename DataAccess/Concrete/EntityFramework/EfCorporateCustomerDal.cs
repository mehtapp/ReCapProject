using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    internal class EfCorporateCustomerDal : EfEntityRepositoryBase<CorporateCustomer, RentACarContext>, ICorporateCustomerDal
    {
        public void AddCorporateCustomer(CorporateCustomer customer)
        {
            
        }
    }
}
