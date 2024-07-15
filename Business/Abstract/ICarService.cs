using Core.Utilities.Results;
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
        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car );
        
        IDataResult<Car> GetCarById(int id);
        IDataResult<List<Car>> GetCars();

        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>>GetCarsByColourId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();

    }
}
