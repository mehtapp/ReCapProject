﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [ValidationAspect(typeof(ColourValidator))]
        public IResult AddColour(Colour colour)
        {
           // ValidationTool.Validate(new ColourValidator() , colour);
                _colourDal.Add(colour);
                return new SuccessResult(Messages.Added);

            
            //return new ErrorResult(Messages.ErrorForColourAdded);
            //throw new ValidationException();
        }

        public IDataResult<List<Colour>> GetColors()
        {
            int countOfColours = _colourDal.GetAll().Count();
            if (countOfColours == 0)
            {
                //success ama veri yok
                return new SuccessDataResult<List<Colour>>(Messages.ZeroListedData);
            }
            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Colour> GetColourById(int id)
        {
            var result = _colourDal.Get(c => c.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Colour>(result, Messages.GetDataById);
            }
            return new ErrorDataResult<Colour>(Messages.NoData);
        }

        public IResult DeleteColour(Colour colour)
        {
            _colourDal.Delete(colour);
            var result = _colourDal.Get(c => c.Id == colour.Id);
            if (result == null)
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
