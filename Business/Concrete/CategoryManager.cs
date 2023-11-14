using Business.Abstract;
using Business.Constants;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IResult Delete(Category category)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _categoryDal.Delete(category);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccesDataResult<Category>(_categoryDal.Get(x => x.CategoryId == categoryId), Messages.UserNotFound);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccesDataResult<List<Category>>(_categoryDal.GetAll().ToList());
        }
        public IDataResult<List<Category>> GetListActive()
        {
            return new SuccesDataResult<List<Category>>(_categoryDal.GetAll(x => x.CategoryStatus == true).ToList());
        }

        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _categoryDal.Update(category);
            return new SuccesResult(Messages.UserRegistered);
        }
    }
}