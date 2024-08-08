using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public void AddCorporateCustomer(User user, CorporateCustomer customer)
        {
            //User tablosuna ve corporate customer tablosuna kayıt ekle
            using (RentACarContext context = new RentACarContext())
            {
                using (var transaction = context.Database.BeginTransaction()) //2 tabloya veri eklerken hata çıkması ihtimaline karşı
                {
                    try
                    {
                        var addedUser = context.Entry(user);
                        addedUser.State = EntityState.Added;
                        context.SaveChanges();

                        customer.UserId = user.UserId;
                        var addedCustomer = context.Entry(customer);
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

        public void DeleteCorporateCustomer(User user, CorporateCustomer customer)
        {
            using (RentACarContext context = new RentACarContext())
            {
                using (var transaction = context.Database.BeginTransaction()) //2 tabloya veri eklerken hata çıkması ihtimaline karşı
                {
                    try
                    {

                        var deletedCustomer = context.Entry(customer);
                        deletedCustomer.State = EntityState.Deleted;
                        context.SaveChanges();

                        var deletedUser = context.Entry(user);
                        deletedUser.State = EntityState.Deleted;
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

        public List<CorporateCustomerWithUserInfoDto> GetAllCorporateCustomer()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.CorporateCustomers
                             join u in context.Users on c.UserId equals u.UserId
                             select new CorporateCustomerWithUserInfoDto
                             {
                                 UserId = c.UserId,
                                 CorporateCustomerId = c.CorporateId,
                                 CorporateName = c.CompanyName,
                                 UserName = u.UserName,
                                 Email = u.Email,
                                 //Password = u.Password
                             };
                
                return result.ToList();
            }
        }
    }


}
