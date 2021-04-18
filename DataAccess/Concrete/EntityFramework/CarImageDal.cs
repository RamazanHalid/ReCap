using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarImageDal:EfEntityRepositoryBase<CarImage,MySQLContext>, ICarImageDal
    {
      
    }
}