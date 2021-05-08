using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
            var result = BusinessRules.Run(CarImagesCountChecker(carImage.CarId),
                imageResult);

            if (result == null )
            {
                carImage.ImagePath = imageResult.Message;
                carImage.DateCar = DateTime.Now;
                _carImageDal.Add(carImage);
            
                return new SuccessResult(Messages.CarImageAdded);
            }

            return result;

        }

        public IResult Delete(CarImage carImage)
        {
           var result= _carImageDal.Get(c=>c.CarImageId == carImage.CarImageId);
           if (result !=null)
           {
               FileHelper.Delete(result.ImagePath);
               _carImageDal.Delete(result);
               return new SuccessResult(Messages.CarImageDeleted); 
           }
           return new ErrorResult(Messages.CarImageNotFounded);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            
            var result = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (result == null)
            {
                return new ErrorResult();
            }
            var imageResult = FileHelper.Update(file, carImage.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
          
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int carId)
        {
            var result = BusinessRules.Run(ChechIfCarHasNoyAnyImage(carId));
            if (result == null)
            {
                return new SuccessDataResult<List<CarImage> >(_carImageDal.GetAll(c => c.CarId == carId)); 
            }
                // Default image
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarImageId == 14));

        }

        public IResult CarImagesCountChecker(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImagesCountLimited);
            }

            return new SuccessResult("asdasd");
        }

        public IResult ChechIfCarHasNoyAnyImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (result)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
        
    }
}