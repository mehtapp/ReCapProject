﻿using Business.Abstract;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult AddBrand(Brand brand)
        {
            if (brand.Name.Count() < 2)
            {
                return new ErrorResult(Messages.ErrorForBrandAdded);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
            var brand = _brandDal.Get(b => b.Id == id);
            if (brand == null)
            {
                return new ErrorDataResult<Brand>(Messages.DefaultError);
            }
            return new SuccessDataResult<Brand>(brand);
        }

        public IDataResult<List<Brand>> GetBrands()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll() , Messages.Listed );
        }

        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }
    }
}
