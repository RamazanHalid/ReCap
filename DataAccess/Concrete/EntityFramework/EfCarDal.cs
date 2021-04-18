using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,MySQLContext>, ICarDal
    {
      
        public List<CarDetailsDto> GetCarDetailsDtos()
        {
            using (MySQLContext context = new MySQLContext())
            {
                var result = from cr in context.Cars
                    join cl in context.Colors
                        on cr.ColorId equals cl.ColorId
                    join br in context.Brands
                        on cr.BrandId equals br.BrandId
                    select new CarDetailsDto
                    {   DailyPrice = cr.DailyPrice,
                        CarId = cr.CarId,
                        Brand = br.BrandName,
                        ColorName = cl.ColorName,
                        CarName = cr.CarName
                        
                    };
                return result.ToList();

            }
        }
    }
}