using Business.Abstarct;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public IDataResult<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
