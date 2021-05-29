using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserService _userService;
        public CustomerManager(ICustomerDal customerDal, IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(CheckIfCustomerNotUser(customer.UserId));
            if (result != null)
            {
                return result;
            }
            //var result = _userDal.GetAll(p => p.UserId == customer.UserId);
            //if (result.Any())
            //{
            //    _customerDal.Add(customer);
            //    return new SuccessResult(Messages.CustomerAdded);
            //}

            return new SuccessResult(Messages.CustomerAdded);
            
        }
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId==customerId));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        private IResult CheckIfCustomerNotUser(int userId)
        {
            var result = _userService.GetAll();
            if (!result.Data.Any(x => x.UserId == userId))
            {
                return new ErrorResult(Messages.CustomerNotUser);
            }
            return new SuccessResult();

        }
    }
}
