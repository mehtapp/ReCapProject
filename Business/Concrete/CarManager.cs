using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
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
        public void AddCar(Car car)
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

        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetCars()
        {
            return _carDal.GetAll();
        }

        public Car GetCarById(int id)
        {
            //return _carDal.GetByID(id)
            return new Car();
        }

        public void UpdateCar(Car car)
        {
            //_carDal.Update(car);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColourId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }


    }
}
