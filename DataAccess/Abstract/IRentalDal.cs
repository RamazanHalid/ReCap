using System.Collections.Generic;
using Core.DataAccess;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailsDto> GetRentalDetailsDto();
    }
}