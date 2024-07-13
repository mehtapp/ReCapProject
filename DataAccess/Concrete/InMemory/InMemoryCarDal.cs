using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car
                {
                    Id = 1,
                    BrandId = 1,
                    ColorId = 1,
                    DailyPrice = 1200,
                    Description = "Doblo",
                    ModelYear = new DateTime(2023, 01, 01)
                }
            };
        }
        public void Add(Car car)
        {
            if (_cars.Contains(car))
            {
                Console.WriteLine("Sistemde ");
            }
            else
            {
                _cars.Add(car);
            }

        }

        public void Delete(Car car)
        {

            var deletedCar = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(deletedCar);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetByID(int id)
        {
            var selectedCar = _cars.SingleOrDefault(c => c.Id == id);
            return selectedCar;
        }

        public void Update(Car car)
        {
            var updatedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            int i = _cars.IndexOf(updatedCar);
            updatedCar.Id = car.Id;
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.Description = car.Description;
            updatedCar.ModelYear = car.ModelYear;
            _cars[i] = updatedCar;
        }
    }
}
