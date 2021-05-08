using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarImageDal:EfEntityRepositoryBase<CarImage,MySQLContext>, ICarImageDal
    {
     /*   public IDataResult<CarImage> GetImageByCarId(int carId)
        {
            using (MySQLContext mySqlContext = new MySQLContext())
            {
                var result
            }
        }*/
    }
}