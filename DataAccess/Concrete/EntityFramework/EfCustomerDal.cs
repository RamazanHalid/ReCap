using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:ICustomerDal
    {
        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            using (MySQLContext context = new MySQLContext())
            {
                return filter == null
                    ? context.Set<Customer>().ToList()
                    : context.Set<Customer>().Where(filter).ToList();
            }
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            using (MySQLContext context = new MySQLContext())
            {
                return context.Set<Customer>().SingleOrDefault(filter);
            }
        }

        public void Add(Customer entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Customer entity)
        {
            using (MySQLContext context = new MySQLContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Customer entity)
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