using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserrId == id));
        }

        


        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            if (_customerDal.Get(c => c.UserrId == customer.UserrId) == null)
            {
                return new ErrorResult(Messages.NameInvalid);
            }

            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Customer customer)
        {
            var result = _customerDal.Get(c => c.UserrId == customer.UserrId);
            if (result == null)
            {
                return new ErrorResult(Messages.NameInvalid);
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.Added);
        }
    }
}