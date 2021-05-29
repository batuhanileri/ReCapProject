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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfNotDelivered(rental.CarId));
            if(result !=null)
            {
                return result;
            }
            
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {          
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==rentalId));

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);

        }
        private IResult CheckIfNotDelivered(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId && c.ReturnDate == null);
            if (result.Any())
            {
                return new ErrorResult(Messages.CarNotDelivered);
            }
            return new SuccessResult();
        }

    }
}
