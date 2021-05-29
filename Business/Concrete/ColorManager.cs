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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        ICarService _carService;

        public ColorManager(IColorDal colorDal, ICarService carService)
        {
            _colorDal = colorDal;
            _carService = carService;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);

        }

        public IResult Delete(Color color)
        {
            IResult result = BusinessRules.Run(CheckIfColorUseCar(color.ColorId));
            if (result != null)
            {
                return result;
            }
            //var result = _carDal.GetAll(c => c.ColorId == color.ColorId);
            //if (result.Any())
            //{
            //    return new ErrorResult(Messages.ColorUse);
            //}
            //else
            //{
            _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());

        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.GetById(colorId));

        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);

        }
        private IResult CheckIfColorUseCar(int colorId)
        {
            var result = _carService.GetAll();
            if (result.Data.Any(x => x.ColorId == colorId))
            {
                return new ErrorResult(Messages.ColorUse);
            }
            return new SuccessResult();

        }
    }
}
