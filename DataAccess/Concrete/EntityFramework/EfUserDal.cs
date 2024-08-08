using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public User AddUser(User user)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var AddedUser = context.Entry(user);
                AddedUser.State = EntityState.Added;
                context.SaveChanges();  //SaveChanges işleminden sonra yolladığımız nesneye Id'si gelir.
                return user;
            }
        }

        
        public List<OperationClaim> GetClaims(User user)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from uOc in context.UserOperationClaims
                             join
                             oc in context.OperationClaims on
                             uOc.OperationClaimId equals oc.Id
                             where uOc.UserId == user.UserId
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };
                return result.ToList();

            }
        }
    }
}
