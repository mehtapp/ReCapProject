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
            _carDal.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAllCars()
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
            _carDal.Update(car);
        }
    }
}
