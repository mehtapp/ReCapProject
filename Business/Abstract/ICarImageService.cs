using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddCarImage(CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IDataResult<List<CarImage>> GetAllCarImage();
        IDataResult<CarImage> GetCarImageById(int id);
        IResult UpdateCarImage(CarImage carImage);


    }
}
