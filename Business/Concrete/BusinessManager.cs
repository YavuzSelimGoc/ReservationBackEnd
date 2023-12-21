using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BusinessManager : IBusinessService
    {
        IBusinessDal _businessDal;

        public BusinessManager(IBusinessDal businessDal)
        {
            _businessDal = businessDal;
        }

        public IResult Add(Entities.Concrete.Business business)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _businessDal.Add(business);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IResult Delete(Entities.Concrete.Business business)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _businessDal.Delete(business);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IDataResult<Entities.Concrete.Business> GetById(int businessId)
        {
            return new SuccesDataResult<Entities.Concrete.Business>(_businessDal.Get(x => x.BusinessId == businessId), Messages.UserNotFound);
        }

        public IDataResult<List<BusinessDto>> GetBusinessDetailsDto()
        {

            return new SuccesDataResult<List<BusinessDto>>(_businessDal.GetBusinessDetails(), Messages.ProductAdded);
        }
        public IDataResult<List<BusinessDto>> GetBusinessDetailsActiveDto()
        {

            return new SuccesDataResult<List<BusinessDto>>(_businessDal.GetBusinessDetailsActive(), Messages.ProductAdded);
        }
        public IDataResult<List<BusinessDto>> GetBusinessDetailsDtoByCategoryId(int categoryId)
        {

            return new SuccesDataResult<List<BusinessDto>>(_businessDal.GetBusinessByCategoryId(categoryId), Messages.ProductAdded);
        }

        public IDataResult<List<Entities.Concrete.Business>> GetList()
        {
            return new SuccesDataResult<List<Entities.Concrete.Business>>(_businessDal.GetAll().ToList());
        }
        public IDataResult<Entities.Concrete.Business> GetListByUserName(string userName)
        {
            return new SuccesDataResult<Entities.Concrete.Business>(_businessDal.Get(x => x.userName == userName), Messages.UserNotFound);
        }
        public IDataResult<List<Entities.Concrete.Business>> GetListActive()
        {
            return new SuccesDataResult<List<Entities.Concrete.Business>>(_businessDal.GetAll(x => x.BusinessStatus == true).ToList());
        }

        public IResult Update(Entities.Concrete.Business business)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _businessDal.Update(business);
            return new SuccesResult(Messages.UserRegistered);
        }
    }
}