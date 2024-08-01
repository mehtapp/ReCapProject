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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _iCarImageDal;

        public CarImageManager(ICarImageDal iCarImageDal)
        {
            _iCarImageDal = iCarImageDal;
        }

        public IResult AddCarImage(CarImage carImage)
        {
            _iCarImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult UpdateCarImage(CarImage carImage)
        {
            _iCarImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            _iCarImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAllCarImage()
        {
            return new SuccessDataResult<List<CarImage>>(_iCarImageDal.GetAll() , Messages.Listed);
        }

        public IDataResult<CarImage> GetCarImageById(int id)
        {
            return new SuccessDataResult<CarImage>(_iCarImageDal.Get(carImage => carImage.Id == id) , Messages.GetDataById);
        }
    }
}
