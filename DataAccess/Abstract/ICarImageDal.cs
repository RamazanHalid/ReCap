using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarImageDal:IEntityRepository<CarImage>
    {
        //IDataResult<CarImage> GetImageByCarId(int carId);
    }
}