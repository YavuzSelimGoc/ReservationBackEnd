using Business.Abstract;
using Business.Constants;
using Castle.Core.Resource;
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
    public class ReservationManager : IReservationService
    {
        IReservationDal _customerDal;

        public ReservationManager(IReservationDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Reservation customer)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IResult Delete(Reservation customer)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _customerDal.Delete(customer);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IDataResult<Reservation> GetById(int customerId)
        {
            return new SuccesDataResult<Reservation>(_customerDal.Get(x => x.ReservationId == customerId), Messages.UserNotFound);
        }

        public IDataResult<List<Reservation>> GetList()
        {
            return new SuccesDataResult<List<Reservation>>(_customerDal.GetAll().ToList());
        }
        public IDataResult<List<ReservationDto>> GetListByUserNameForCustomer(string userName)
        {
            return new SuccesDataResult<List<ReservationDto>>(_customerDal.GetReservationDetailsByCustomerUserName(userName).ToList());
        }
        public IDataResult<List<ReservationDto>> GetListByUserNameForCustomerActive(string userName)
        {
            return new SuccesDataResult<List<ReservationDto>>(_customerDal.GetReservationDetailsByCustomerUserNameActive(userName).ToList());
        }
        public IDataResult<List<ReservationDto>> GetListByUserNameForBusiness(string userName)
        {
            return new SuccesDataResult<List<ReservationDto>>(_customerDal.GetReservationDetailsByBusinessUserName(userName).ToList());
        }
        public IDataResult<List<ReservationDto>> GetListByUserNameForBusinessActive(string userName)
        {
            return new SuccesDataResult<List<ReservationDto>>(_customerDal.GetReservationDetailsByBusinessUserNameActive(userName).ToList());
        }

        public IDataResult<List<Reservation>> GetListActive()
        {
            return new SuccesDataResult<List<Reservation>>(_customerDal.GetAll(x => x.ReservationStatus == true).ToList());
        }

        public IResult Update(Reservation customer)
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