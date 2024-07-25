using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        void DeliverACarBack(Rental rental);
        //List<Rental> GetAvailableCarForRent();
        List<Rental> GetRentedCarById(int CarId);
      
    }
}
