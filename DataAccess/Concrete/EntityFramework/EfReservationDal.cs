using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfReservationDal : EfRepositoryBase<Reservation, ReservationContext>, IReservationDal
    {
        public List<ReservationDto> GetReservationDetails()
        {
            using (ReservationContext reservationContext = new ReservationContext())
            {
                var result = from r in reservationContext.Reservations
                             join b in reservationContext.Businesses
                             on r.BusinessUserName equals b.userName
                             join c in reservationContext.Customers
                           on r.CustomerUserName equals c.UserName


                             select new ReservationDto
                             {
                                ReservationId=r.ReservationId,
                                ReservationDescription=r.ReservationDescription,
                                CustomerDescription=c.CustomerDescription,
                                Hour=r.Hour,
                                ReservationStatus=r.ReservationStatus,
                                BusinessUserName=r.BusinessUserName,
                                CustomerUserName=r.CustomerUserName,
                                BusinessName=b.BusinessName,
                                isAccept=r.isAccept,
                                CustomerName=c.CustomerName

                             };
                return result.ToList();
            }

        }
        public List<ReservationDto> GetReservationDetailsByCustomerUserName(string userName)
        {
            using (ReservationContext reservationContext = new ReservationContext())
            {
                var result = from r in reservationContext.Reservations
                             join b in reservationContext.Businesses
                             on r.BusinessUserName equals b.userName
                             join c in reservationContext.Customers
                           on r.CustomerUserName equals c.UserName
                           where r.CustomerUserName==userName


                             select new ReservationDto
                             {
                                 ReservationId = r.ReservationId,
                                 ReservationDescription = r.ReservationDescription,
                                 CustomerDescription = c.CustomerDescription,
                                 ReservationStatus = r.ReservationStatus,
                                 Hour=r.Hour,
                                 BusinessUserName = r.BusinessUserName,
                                 CustomerUserName = r.CustomerUserName,
                                 BusinessName = b.BusinessName,
                                 isAccept = r.isAccept,
                                 CustomerName = c.CustomerName

                             };
                return result.ToList();
            }

        }
        public List<ReservationDto> GetReservationDetailsByCustomerUserNameActive(string userName)
        {
            using (ReservationContext reservationContext = new ReservationContext())
            {
                var result = from r in reservationContext.Reservations
                             join b in reservationContext.Businesses
                             on r.BusinessUserName equals b.userName
                             join c in reservationContext.Customers
                           on r.CustomerUserName equals c.UserName
                             where r.CustomerUserName == userName
                             && r.ReservationStatus==true


                             select new ReservationDto
                             {
                                 ReservationId = r.ReservationId,
                                 ReservationDescription = r.ReservationDescription,
                                 CustomerDescription = c.CustomerDescription,
                                 ReservationStatus = r.ReservationStatus,
                                 BusinessUserName = r.BusinessUserName,
                                 Hour=r.Hour,
                                 CustomerUserName = r.CustomerUserName,
                                 BusinessName = b.BusinessName,
                                 isAccept = r.isAccept,
                                 CustomerName = c.CustomerName

                             };
                return result.ToList();
            }

        }
        public List<ReservationDto> GetReservationDetailsByBusinessUserNameActive(string userName)
        {
            using (ReservationContext reservationContext = new ReservationContext())
            {
                var result = from r in reservationContext.Reservations
                             join b in reservationContext.Businesses
                             on r.BusinessUserName equals b.userName
                             join c in reservationContext.Customers
                           on r.CustomerUserName equals c.UserName
                           where r.BusinessUserName==userName
                             && r.ReservationStatus==true


                             select new ReservationDto
                             {
                                 ReservationId = r.ReservationId,
                                 ReservationDescription = r.ReservationDescription,
                                 CustomerDescription = c.CustomerDescription,
                                 ReservationStatus = r.ReservationStatus,
                                 Hour=r.Hour,
                                 BusinessUserName = r.BusinessUserName,
                                 CustomerUserName = r.CustomerUserName,
                                 BusinessName = b.BusinessName,
                                 isAccept = r.isAccept,
                                 CustomerName = c.CustomerName

                             };
                return result.ToList();
            }

        }
        public List<ReservationDto> GetReservationDetailsByBusinessUserName(string userName)
        {
            using (ReservationContext reservationContext = new ReservationContext())
            {
                var result = from r in reservationContext.Reservations
                             join b in reservationContext.Businesses
                             on r.BusinessUserName equals b.userName
                             join c in reservationContext.Customers
                           on r.CustomerUserName equals c.UserName
                             where r.BusinessUserName == userName



                             select new ReservationDto
                             {
                                 ReservationId = r.ReservationId,
                                 ReservationDescription = r.ReservationDescription,
                                 CustomerDescription = c.CustomerDescription,
                                 Hour=r.Hour,
                                 ReservationStatus = r.ReservationStatus,
                                 BusinessUserName = r.BusinessUserName,
                                 CustomerUserName = r.CustomerUserName,
                                 BusinessName = b.BusinessName,
                                 isAccept = r.isAccept,
                                 CustomerName = c.CustomerName

                             };
                return result.ToList();
            }

        }
    }
}

