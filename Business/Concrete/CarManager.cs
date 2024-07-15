using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult AddCar(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araç bilgilerini eksik veya hatalı girdiniz.");
            }

        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetCars()
        {
            return _carDal.GetAll();
        }

        public IDataResult<Car> GetCarById(int id)
        {
            return _carDal.Get(c => c.Id == id);
            //return new Car();
        }

        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public IDataResult<List<Car>> GetCarsByColourId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
