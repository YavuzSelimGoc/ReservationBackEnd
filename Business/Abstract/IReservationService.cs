using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IReservationService
    {
        IDataResult<Reservation> GetById(int reservationId);
        IDataResult<List<Reservation>> GetList();
        IDataResult<List<ReservationDto>> GetListDto();
        IDataResult<List<ReservationDto>> GetListByUserNameForCustomer(string userName);
        IDataResult<List<ReservationDto>> GetListByUserNameForCustomerActive(string userName);
        IDataResult<List<ReservationDto>> GetListByUserNameForBusiness(string userName);
        IDataResult<List<ReservationDto>> GetListByUserNameForBusinessActive(string userName);
        IDataResult<List<Reservation>> GetListActive();
        IResult Add(Reservation reservation);
        IResult Delete(Reservation reservation);
        IResult Update(Reservation reservation);
    }
}
