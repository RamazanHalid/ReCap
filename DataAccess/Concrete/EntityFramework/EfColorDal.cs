using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:IEntityRepository<Color>
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (MySQLContext context = new MySQLContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (MySQLContext context = new MySQLContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Add(Color entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Color entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
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