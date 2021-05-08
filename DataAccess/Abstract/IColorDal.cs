using Core.DataAccess;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal:IEntityRepository<Color>
    {
        
    }
}