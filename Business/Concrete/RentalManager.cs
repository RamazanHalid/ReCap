using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }

        


        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            if (_rentalDal.Get(c => c.Id == rental.Id) == null)
            {
                return new ErrorResult(Messages.NameInvalid);
            }

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(c => c.Id == rental.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.NameInvalid);
            }

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Added);
        }
    }
}