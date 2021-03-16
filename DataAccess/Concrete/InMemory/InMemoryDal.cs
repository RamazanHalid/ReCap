using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal:ICarDal
    {
        private List<Car> _car;

        public InMemoryDal()
        {
            _car = new List<Car>
            {
                new Car
                {
                    CarId = 1, 
                    ColorId = 1,
                    BrandId = 1 ,
                    ModelYear = 2015 ,
                     DailyPrice = 250,
                      Description = "Super car"
                },
                new Car
                {
                    CarId = 2, 
                    ColorId = 2,
                    BrandId = 2 ,
                    ModelYear = 2005 ,
                    DailyPrice = 50,
                    Description = "Old car"
                },
                new Car
                {
                    CarId = 3, 
                    ColorId = 3,
                    BrandId = 2 ,
                    ModelYear = 1997 ,
                    DailyPrice = 20,
                    Description = "Older car"
                }
            };
        }

        public Car GetById(int carId)
        {
            return _car.SingleOrDefault(c => c.CarId == carId);
        }

       

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Update(Car car)
        {
            Car toUpdateCar = _car.SingleOrDefault(c => c.CarId == car.CarId);
            toUpdateCar.ColorId = car.ColorId;
            toUpdateCar.ModelYear = car.ModelYear;
            toUpdateCar.Description = car.Description;
            toUpdateCar.BrandId = car.BrandId;
            toUpdateCar.DailyPrice = car.DailyPrice;
            
        } 

        public void Delete(Car car)
        {
            Car toDeleteCar = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(toDeleteCar);


        }

        public List<CarDetailsDto> GetCarDetailsDtos()
        {
            throw new NotImplementedException();
        }
    }
}