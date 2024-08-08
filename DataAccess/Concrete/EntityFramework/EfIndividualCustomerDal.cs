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
        public IndividualCustomer AddIndividualCustomer(IndividualCustomer individualCustomer)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedCustomer = context.Entry(individualCustomer);
                addedCustomer.State = EntityState.Added;
                context.SaveChanges();
                return individualCustomer;
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
                        //Password = u.Password,
                        UserName = u.UserName
                    };
                return result.ToList();
            }

        }

        //public void UpdateIndividualCustomer(User user, IndividualCustomer customer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
