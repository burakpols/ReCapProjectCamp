using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _carList;

        public InMemoryCarDal(List<Car> carList)
        {
            _carList = new List<Car>
            {
                new Car{ Id=1,BrandId=1,ColorId=4,DailyPrice=140,ModelYear=2014,Descriptions="1 Nolu Araç Açıklaması" },
                new Car{ Id=2,BrandId=2,ColorId=3,DailyPrice=125,ModelYear=2012,Descriptions="2 Nolu Araç Açıklaması" },
                new Car{ Id=3,BrandId=3,ColorId=5,DailyPrice=150,ModelYear=2015,Descriptions="3 Nolu Araç Açıklaması" },
                new Car{ Id=4,BrandId=4,ColorId=4,DailyPrice=210,ModelYear=2018,Descriptions="4 Nolu Araç Açıklaması" },
                new Car{ Id=5,BrandId=5,ColorId=8,DailyPrice=180,ModelYear=2016,Descriptions="5 Nolu Araç Açıklaması" }

            };
        }

        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = _carList.SingleOrDefault(c => c.Id == car.Id);
            _carList.Remove(deletedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return null;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return null;
        }

        public void Update(Car car)
        {
            Car _updateToCar = _carList.FirstOrDefault(c => c.Id == car.Id);
            _updateToCar.BrandId = car.BrandId;
            _updateToCar.ColorId = car.ColorId;
            _updateToCar.DailyPrice = car.DailyPrice;
            _updateToCar.ModelYear = car.ModelYear;
            _updateToCar.Descriptions = car.Descriptions;
        }
    }
}
