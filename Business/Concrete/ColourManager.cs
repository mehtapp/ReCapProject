using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        private readonly IColourDal _colourDal;
        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }
        public IResult AddColour(Colour colour)
        {
            if (colour.Name.Length <= 2)
            {
                return new ErrorResult(Messages.ErrorForColourAdded);
            }
            _colourDal.Add(colour);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Colour>> GetColors()
        {
            int countOfColours = _colourDal.GetAll().Count();
            if (countOfColours == 0)
            {
                //success ama veri yok
                return new SuccessDataResult<List<Colour>>(Messages.zeroListedData);
            }
            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Colour> GetColourById(int id)
        {
            return new SuccessDataResult<Colour>(_colourDal.Get(c => c.Id == id));
        }

        public IResult DeleteColour(Colour colour)
        {
            _colourDal.Delete(colour);
            var result = _colourDal.Get(c => c.Id == colour.Id);
            if ( result == null)
            {
                return new SuccessResult("Başarıyla silindi.");
            }
            return new ErrorResult(Messages.DefaultError);


        }

        public IResult UpdateColour(Colour colour)
        {
            _colourDal.Update(colour);
            return new SuccessResult(Messages.Updated);
        }


    }
}
