using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface IRentallService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<List<RentallDetailDto>> GetRentalDetailsDto(int carId);
        IResult Add(Rentals rental);
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(int carId);
    }
}
