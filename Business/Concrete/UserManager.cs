using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        ICustomerDal _customerDal;
        public UserManager(IUserDal userDal,ICustomerDal customerDal)
        {
            _userDal = userDal;
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(UserValidator))]

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);

        }

        public IResult Delete(User user)
        {
            var result = _customerDal.GetAll(p => p.UserId == user.UserId);
            if (result.Any())
            {
                return new ErrorResult(Messages.UserUseCannotDeleteTheCustomer);
            }
            else
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);

        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }   

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
