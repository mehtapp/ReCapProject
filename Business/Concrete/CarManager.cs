using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            { _carDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.DefaultError);
            }

        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetCarById(int id)
        {

            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
            //return new Car();
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColourId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
