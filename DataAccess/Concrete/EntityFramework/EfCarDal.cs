using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (MySQLContext context = new MySQLContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (MySQLContext context = new MySQLContext())
            {
                return context.Set<Car>().SingleOrDefault(filter); 
            }
        }

        public void Add(Car entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

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