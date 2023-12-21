using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System.Linq;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBusinessDal : EfRepositoryBase<Business, ReservationContext>, IBusinessDal
    {
        public List<BusinessDto> GetBusinessDetails()
        {
            using (ReservationContext reservationContext = new ReservationContext())
            {
                var result = from b in reservationContext.Businesses
                             join c in reservationContext.Category
                             on b.CategoryId equals c.CategoryId


                             select new BusinessDto
                             {
                                 BusinessId=b.BusinessId,
                                 BusinessAdress=b.BusinessAdress,
                                 CategoryName=c.CategoryName,
                                 BusinessPhoneNumber=b.BusinessPhoneNumber,
                                 userName =b.userName,
                                 BusinessDescription=b.BusinessDescription,
                                 BusinessImage=b.BusinessImage,
                                 BusinessMaxPrice=b.BusinessMaxPrice,
                                 BusinessMinPrice=b.BusinessMinPrice,
                                 BusinessName=b.BusinessName,
                                 BusinessShortDescription=b.BusinessShortDescription,
                                 BusinessStatus=b.BusinessStatus,
                                
                             };
                return result.ToList();
            }

        }
        public List<BusinessDto> GetBusinessDetailsActive()
        {
            using (ReservationContext reservationContext = new ReservationContext())
            {
                var result = from b in reservationContext.Businesses
                             join c in reservationContext.Category
                             on b.CategoryId equals c.CategoryId
                             where b.BusinessStatus==true
                             select new BusinessDto
                             {
                                 BusinessId = b.BusinessId,
                                 BusinessAdress = b.BusinessAdress,
                                 CategoryName = c.CategoryName,
                                 BusinessPhoneNumber = b.BusinessPhoneNumber,
                                 userName = b.userName,
                                 BusinessDescription = b.BusinessDescription,
                                 BusinessImage = b.BusinessImage,
                                 BusinessMaxPrice = b.BusinessMaxPrice,
                                 BusinessMinPrice = b.BusinessMinPrice,
                                 BusinessName = b.BusinessName,
                                 BusinessShortDescription = b.BusinessShortDescription,
                                 BusinessStatus = b.BusinessStatus,

                             };
                return result.ToList();
            }

        }
        public List<BusinessDto> GetBusinessByCategoryId(int categoryId)
        {
            using (ReservationContext reservationContext = new ReservationContext())
            {
                var result = from b in reservationContext.Businesses
                             join c in reservationContext.Category
                             on b.CategoryId equals c.CategoryId
                             where b.BusinessStatus==true && b.CategoryId==categoryId
                             select new BusinessDto
                             {
                                 BusinessId = b.BusinessId,
                                 BusinessAdress = b.BusinessAdress,
                                 BusinessPhoneNumber = b.BusinessPhoneNumber,
                                 CategoryName = c.CategoryName,
                                 userName = b.userName,
                                 BusinessDescription = b.BusinessDescription,
                                 BusinessImage = b.BusinessImage,
                                 BusinessMaxPrice = b.BusinessMaxPrice,
                                 BusinessMinPrice = b.BusinessMinPrice,
                                 BusinessName = b.BusinessName,
                                 BusinessShortDescription = b.BusinessShortDescription,
                                 BusinessStatus = b.BusinessStatus,

                             };
                return result.ToList();
            }

        }
    }

}

