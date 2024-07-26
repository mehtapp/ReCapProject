using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult AddRentedCar(Rental rental)
        {
            //bu araç şuan kiralanabilir durumda mı?
            //*************************************************
            Rental alreadyRentedCar = _rentalDal.GetRentedCarById(rental.CarId).SingleOrDefault(r => r.ReturnDate == null);
            if (alreadyRentedCar == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.CantRentThisCar);


        }

        public IResult DeleteRentedCar(Rental rental)
        {
            //Aracın silinmesi için kiralık verilmiş durumda olmaması lazım ?
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult DeliverACarBack(Rental rental)   //aracı müşteri teslim ediyor 
        {
            _rentalDal.DeliverACarBack(rental);
            return new SuccessResult(Messages.DeliverCarBack);
        }

        //public IDataResult<List<Rental>> GetAvailableCarForRent() //Sadece kiralanabilecek araçlar listesi
        //{
        //    return new SuccessDataResult<List<Rental>>(_rentalDal.GetAvailableCarForRent(), Messages.Listed);

        //}

        public IDataResult<List<Rental>> GetRentedCarById(int CarId) //bir aracın geçmişteki kiralanma listesi ve şuan kiralanmışsa o bilgi
        {
            _rentalDal.GetRentedCarById(CarId);
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetRentedCarById(CarId), Messages.Listed);
        }

        public IDataResult<List<Rental>> GetAllRentedCars()  //
        {
            return new SuccessDataResult<List<Rental>>
                 (
                _rentalDal.GetAll(),
                Messages.Listed
                );
        }

        public IResult UpdateRentedCar(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
