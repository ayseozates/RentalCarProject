using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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
               _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int RentalId)
        {
            var result = _rentalDal.Get(p => p.Id == RentalId);
            if (result != null)
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == RentalId));
            }
            else
            {
                return new ErrorDataResult<Rental>(_rentalDal.Get(p => p.Id == RentalId));

            }
        }

        public IDataResult<Rental> GetCarsByCustomerId(int CustomerId)
        {
            var result = _rentalDal.Get(p => p.CustomerId == CustomerId);
            if (result != null)
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CustomerId == CustomerId));
            }
            else
            {
                return new ErrorDataResult<Rental>(_rentalDal.Get(p => p.CustomerId == CustomerId));

            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<Rental> GetRentalsByCarId(int carId)
        {
            var result = _rentalDal.Get(p => p.CarId == carId);
            if (result != null)
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CarId == carId));
            }
            else
            {
                return new ErrorDataResult<Rental>(_rentalDal.Get(p => p.CarId == carId));

            }
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
           
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Updated);
            
        }

        
    }
}
