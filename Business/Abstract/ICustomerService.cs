﻿using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(int customerId);
        IDataResult<List<Customer>> GetList();
        IDataResult<Customer> GetListByUserName(string userName);
        IDataResult<List<Customer>> GetListActive();
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
