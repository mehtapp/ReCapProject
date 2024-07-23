using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfIndividualCustomerDal : EfEntityRepositoryBase<IndividualCustomer, RentACarContext>, IIndividualCustomerDal
    {
        public void AddIndividualCustomer(User user, IndividualCustomer customer)
        {
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

        public void DeleteIndividualCustomer(User user, IndividualCustomer customer)
        {
            using (RentACarContext context = new RentACarContext())
            {
                using (var transaction = context.Database.BeginTransaction())
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

        public List<IndividualCustomerWithUserInfoDto> GetAllIndividualCustomer()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =
                    from u in context.Users
                    join
                    ic in context.IndividualCustomers
                    on u.UserId equals ic.UserId
                    select new IndividualCustomerWithUserInfoDto
                    {
                        UserId = u.UserId,
                        Email = u.Email,
                        FirstName = ic.FirstName,
                        LastName = ic.LastName,
                        IndividualCustomerId = ic.IndividualCustomerId,
                        Password = u.Password,
                        UserName = u.UserName
                    };
                return result.ToList();
            }
            
        }
    }
}
