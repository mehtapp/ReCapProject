using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }



        public IResult AddCarImage(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCountOfImageForACar(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var ImagePath = _fileHelper.Upload(file, PathConstant.ImagesPath);
            if (ImagePath != null)
            {
                carImage.Date = DateTime.Now;
                carImage.ImagePath = ImagePath;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.DefaultError);
        }

        public IResult UpdateCarImage(IFormFile file, CarImage carImage)
        {
            //ImagePath postmanden almamak için
            var currentCarImage = _carImageDal.Get(x => x.CarId == carImage.CarId && x.Id == carImage.Id);
            string newPath = _fileHelper.Update(file, currentCarImage.ImagePath, PathConstant.ImagesPath);
            carImage.ImagePath = newPath;
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        public IResult DeleteCarImage(params int[] CarImageIds)
        {
            foreach (var id in CarImageIds)
            {
                CarImage carImage = _carImageDal.Get(c => c.Id == id);
                _fileHelper.Delete(carImage.ImagePath, PathConstant.ImagesPath);
                _carImageDal.Delete(carImage);
            }

            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAllCarImage()
        {
            //BusinessRules.Run(CheckCarImage());
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CarImage> GetCarImageById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(carImage => carImage.Id == id));
        }
        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            IResult IsDefaultImage = BusinessRules.Run((IResult)CheckCarImage(id));

            if (IsDefaultImage == null) //null değilse Car image tablosunda bu araca ait bir kayıt yok demektir. 
                                     // kayıt atılmadıysa mantık olarak görseli de olmaz.
               return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
            else
            
                return new SuccessDataResult<List<CarImage>>(CheckCarImage(id).Data);
            
        }

        private IResult CheckCountOfImageForACar(int CarId)
        {
            int count = _carImageDal.GetAll(x => x.CarId == CarId).Count;
            if (count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitError);
            }
            return new SuccessResult();
        }


        private IDataResult<List<CarImage>> CheckCarImage(int CarId)
        {
            int count = _carImageDal.GetAll(x => x.CarId == CarId).Count();
            if (count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(Messages.Listed);
            }
           
            return new ErrorDataResult<List<CarImage>>(new List<CarImage>() 
            { 
                new CarImage 
                { 
                    CarId = CarId , 
                    ImagePath=PathConstant.ImagesPath+"defaultImageForCar.png"
                } 
            });


        }


    }
}
