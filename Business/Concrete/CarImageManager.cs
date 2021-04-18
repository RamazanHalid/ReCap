using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    
    
    public class CarImageManager:ICarImageService
    {
         ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.CarImageId==id));
        }

        public IResult Add(IFormFile file ,CarImage carImage)
        {
            var imageResult = FileHelper.Add(file);

            if (imageResult.Success)
            {
                carImage.ImagePath = imageResult.Message;
                carImage.DateCar = DateTime.Now;
                _carImageDal.Add(carImage);
            
                return new SuccessResult(Messages.CarImageAdded);
            }

            return new ErrorResult("Car not added!");

        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}