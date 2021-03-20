using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:IRentalDal
    {
        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            using (MySQLContext context = new MySQLContext())
            {
                return filter == null
                    ? context.Set<Rental>().ToList()
                    : context.Set<Rental>().Where(filter).ToList();
            }
        }

        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            using (MySQLContext context = new MySQLContext())
            {
                return context.Set<Rental>().SingleOrDefault(filter);
            }
        }

        public void Add(Rental entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Rental entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Rental entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}