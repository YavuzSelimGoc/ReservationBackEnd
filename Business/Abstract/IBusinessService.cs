using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBusinessService
    {
        IDataResult<Entities.Concrete.Business> GetById(int categoryId);
        IDataResult<List<Entities.Concrete.Business>> GetList();
        IDataResult<List<Entities.Concrete.Business>> GetListActive();
        IResult Add(Entities.Concrete.Business category);
        IResult Delete(Entities.Concrete.Business category);
        IResult Update(Entities.Concrete.Business category);
    }
}
