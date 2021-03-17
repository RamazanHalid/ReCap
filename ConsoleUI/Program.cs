using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
   
            Car car1 = new Car();
            car1.CarId = 134;
            car1.CarName = "E180 AMG";
            car1.BrandId = 3;
            car1.ColorId = 3;
            car1.Description = "Perfect Car";
            car1.DailyPrice = 350;
            car1.ModelYear = 2021;
            
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}