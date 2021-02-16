using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentallService
    {
        IRentalDal _rental;

        public RentalManager(IRentalDal rental)
        {
            _rental = rental;
        }

        public IResult Add(Rentals rental)
        {
            _rental.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }

        public IResult CheckReturnDate(int carId)
        {
            var checkedRental = _rental.Get(r => r.Id == carId);
            if (checkedRental.ReturnDate > DateTime.Now)
            {
                return new SuccessResult(Messages.RentalReturnDateNotPassed);
            }
            return new ErrorResult(Messages.RentalReturnDatePassed);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            var getAll = _rental.GetAll();
            return new SuccessDataResult<List<Rentals>>(getAll);
        }

        public IDataResult<List<RentallDetailDto>> GetRentalDetailsDto(int carId)
        {
            var rentalDetails = _rental.GetRentalDetails();
            return new SuccessDataResult<List<RentallDetailDto>>(rentalDetails);
        }

        public IResult UpdateReturnDate(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
