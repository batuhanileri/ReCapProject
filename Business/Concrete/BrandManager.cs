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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        ICarService _carService;
        public BrandManager(IBrandDal brandDal, ICarService carService)
        {
            _brandDal = brandDal;
            _carService = carService;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
           _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandUseCar(brand.BrandId));
            if(result !=null)
            {
                return result;
            }
            //var result = _carDal.GetAll(p => p.BrandId == brand.BrandId);
            //if (result.Any())
            //{
            //    return new ErrorResult(Messages.BrandUse);
            //}
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);       
           
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.GetById(brandId));
        }
        [ValidationAspect(typeof(BrandValidator))]

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);

        }
        private IResult CheckIfBrandUseCar(int brandId)
        {
            var result = _carService.GetAll();
            if (result.Data.Any(x=> x.BrandId ==brandId))
            {
                return new ErrorResult(Messages.BrandUse);
            }
              return new SuccessResult();

        }
    }
}
