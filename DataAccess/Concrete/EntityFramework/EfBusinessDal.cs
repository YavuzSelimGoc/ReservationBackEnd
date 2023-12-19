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
            using (ReservationContext northwindContext = new ReservationContext())
            {
                var result = from b in northwindContext.Businesses
                             join c in northwindContext.Category
                             on b.CategoryId equals c.CategoryId


                             select new BusinessDto
                             {
                                 BusinessId=b.BusinessId,
                                 BusinessAdress=b.BusinessAdress,
                                 CategoryName=c.CategoryName,
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
            using (ReservationContext northwindContext = new ReservationContext())
            {
                var result = from b in northwindContext.Businesses
                             join c in northwindContext.Category
                             on b.CategoryId equals c.CategoryId
                             where b.BusinessStatus==true
                             select new BusinessDto
                             {
                                 BusinessId = b.BusinessId,
                                 BusinessAdress = b.BusinessAdress,
                                 CategoryName = c.CategoryName,
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
            using (ReservationContext northwindContext = new ReservationContext())
            {
                var result = from b in northwindContext.Businesses
                             join c in northwindContext.Category
                             on b.CategoryId equals c.CategoryId
                             where b.BusinessStatus==true && b.CategoryId==categoryId
                             select new BusinessDto
                             {
                                 BusinessId = b.BusinessId,
                                 BusinessAdress = b.BusinessAdress,
                                 CategoryName = c.CategoryName,
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

