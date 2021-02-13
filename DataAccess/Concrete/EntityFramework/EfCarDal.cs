using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal: EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {


        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from ca in filter is null ? context.Cars : context.Cars.Where(filter)
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,

                             };

                return result.ToList();

            }
        }
    }
}
