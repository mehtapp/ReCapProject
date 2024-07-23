using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCorporateCustomerDal : EfEntityRepositoryBase<CorporateCustomer, RentACarContext>, ICorporateCustomerDal
    {
        public void AddCorporateCustomer(User user ,CorporateCustomer customer)
        {
            //User tablosuna ve corporate customer tablosuna kayıt ekle
            using (RentACarContext context = new RentACarContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var addedUser = context.Entry(user);
                        addedUser.State = EntityState.Added;
                        context.SaveChanges();

                        customer.UserId = user.UserId;
                        var addedCustomer = context.Entry(user);
                        addedCustomer.State = EntityState.Added;
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
                
        }

    }
}
