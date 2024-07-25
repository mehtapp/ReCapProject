using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public void DeliverACarBack(Rental rental)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var query = context.Rentals.Where(r => r.Id == rental.Id && r.ReturnDate == null);
                if (query.Any()) 
                {
                    rental.ReturnDate = DateTime.Now;
                    var deliverCarBack = context.Entry(rental);
                    deliverCarBack.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        //public List<Rental> GetAvailableCarForRent()
        //{
        //    throw new Exception();
        //}


        public List<Rental> GetRentedCarById(int CarId) //spesific aracın geçmiş ve şimdiki kiralanma durumları listesi
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Rentals.Where(r => r.CarId == CarId).ToList();
            }
        }

        
    }
}
