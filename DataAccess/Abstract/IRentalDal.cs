﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rentals>
    {
        List<RentallDetailDto> GetRentalDetails(Expression<Func<Rentals, bool>> filter = null);
    }
}