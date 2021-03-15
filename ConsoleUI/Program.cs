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
            CarManager carManager = new CarManager(new EfCarDal());
            Car carr = new Car();
            carr.ModelYear = 2015;
            carr.Description = "asdasd";
            carr.BrandId = 1;
            carr.ColorId = 1;
            carr.DailyPrice = 100;
            carr.CarId = 12;
            carManager.Add(carr);
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.ModelYear);
            }
            
        }
    }
}