using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManeger : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManeger(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Day == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == id));
        }

        


        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (_brandDal.Get(c => c.BrandId == brand.BrandId) == null)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }

            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IResult Update(Brand brand)
        {
            var result = _brandDal.Get(c => c.BrandId == brand.BrandId);
            if (result == null)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandAdded);
        }
    }
}