using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        public IResult AddRentedCar(Rental rental) 
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRentedCar(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult DeliverACar()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAvailableCarForRent()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetRentedCarById(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetRentedCars()
        {
            throw new NotImplementedException();
        }

        public IResult UpdateRentedCar(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
