using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car );
        
        Car GetCarById(int id);
        List<Car> GetCars();

        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColourId(int id);
        List<CarDetailDto> GetCarDetails();

    }
}
