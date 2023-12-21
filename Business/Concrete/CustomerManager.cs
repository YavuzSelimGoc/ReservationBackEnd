using Business.Abstract;
using Business.Constants;
using Castle.Core.Resource;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IResult Delete(Customer customer)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _customerDal.Delete(customer);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccesDataResult<Customer>(_customerDal.Get(x => x.CustomerId == customerId), Messages.UserNotFound);
        }

        public IDataResult<List<Customer>> GetList()
        {
            return new SuccesDataResult<List<Customer>>(_customerDal.GetAll().ToList());
        }
        public IDataResult<Customer> GetListByUserName(string userName)
        {
            return new SuccesDataResult<Customer>(_customerDal.Get(x => x.UserName == userName), Messages.UserNotFound);
        }
        public IDataResult<List<Customer>> GetListActive()
        {
            return new SuccesDataResult<List<Customer>>(_customerDal.GetAll(x => x.CustomerStatus == true).ToList());
        }

        public IResult Update(Customer customer)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _customerDal.Update(customer);
            return new SuccesResult(Messages.UserRegistered);
        }
    }
}