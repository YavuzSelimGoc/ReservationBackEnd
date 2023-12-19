using System;
using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IBusinessDal : IEntityRepository<Business>
    {
        List<BusinessDto> GetBusinessDetails();
        List<BusinessDto> GetBusinessByCategoryId(int categorId);
        List<BusinessDto> GetBusinessDetailsActive();
    }
}

