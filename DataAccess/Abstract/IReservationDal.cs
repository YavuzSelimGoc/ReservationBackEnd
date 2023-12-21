using System;
using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IReservationDal : IEntityRepository<Reservation>
    {
        List<ReservationDto> GetReservationDetails();
        List<ReservationDto> GetReservationDetailsByCustomerUserName(string userName);
        List<ReservationDto> GetReservationDetailsByBusinessUserName(string userName);
        List<ReservationDto> GetReservationDetailsByCustomerUserNameActive(string userName);
        List<ReservationDto> GetReservationDetailsByBusinessUserNameActive(string userName);

    }
}

