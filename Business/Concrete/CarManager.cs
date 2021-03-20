using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IDataResult<List<Car>>  GetAll()
        {
            if (DateTime.Now.Day == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductListed) ;    
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId ==id)) ;
        }

        public IDataResult<List<Car>>  GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id)) ;
        }

        public IDataResult<List<Car>>  GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id)) ;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0 )
            {
                _carDal.Add(car);
                return new SuccessResult( Messages.CarAdded);
                
            }

            return new ErrorResult(Messages.CarNameInvalid);

        }

        public IResult Delete(Car car)
        {
            if (_carDal.Get(c=>c.CarId == car.CarId) == null)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        
        
        

        public IResult Update(Car car)
        {
            var result = _carDal.Get(c => c.CarId == car.CarId);
            if ( result == null)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }


        public IDataResult<List<CarDetailsDto>>  GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>( _carDal.GetCarDetailsDtos());
        }
    }
}