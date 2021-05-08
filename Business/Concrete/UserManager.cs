using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;


namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == id));
        }

        


        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            if (_userDal.Get(c => c.Id == user.Id) == null)
            {
                return new ErrorResult(Messages.NameInvalid);
            }

            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(c => c.Id == user.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.NameInvalid);
            }

            _userDal.Update(user);
            return new SuccessResult(Messages.Added);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}