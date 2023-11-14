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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public IResult Add(Blog blog)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _blogDal.Add(blog);
            return new SuccesResult(Messages.UserNotFound);
        }

        public IResult Delete(Blog blog)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _blogDal.Delete(blog);
            return new SuccesResult(Messages.UserNotFound);
        }
        public IDataResult<List<BlogDetailsDto>> GetBlogDetails()
        {
            
            return new SuccesDataResult<List<BlogDetailsDto>>(_blogDal.GetBlogDetails(),Messages.ProductAdded);
        }

     
        public IDataResult<Blog> GetById(int blogId)
        {
            return new SuccesDataResult<Blog>(_blogDal.Get(x => x.BlogId == blogId), Messages.UserNotFound);
        }
        public IDataResult<Blog> GetBySlug(string slug)
        {
            return new SuccesDataResult<Blog>(_blogDal.Get(x => x.BlogUrl == slug), Messages.UserNotFound);
        }
       
        public IDataResult<List<Blog>> GetList()
        {
            return new SuccesDataResult<List<Blog>>(_blogDal.GetAll().ToList());
        }
        public IDataResult<List<BlogDetailsDto>> GetListByCategoryDto(int categoryId ,int page )
        {
            int postCount = 6;
            int skipCount = page * postCount;

            return new SuccesDataResult<List<BlogDetailsDto>>(_blogDal.GetBlogDetailsByCategoryId(categoryId).OrderByDescending(x => x.BlogId).Skip(skipCount - 6).Take(postCount).ToList());
        }
        public IDataResult<List<BlogDetailsDto>> GetBlogDetailsDto( int page)
        {
            int postCount = 6;
            int skipCount = page * postCount;

            return new SuccesDataResult<List<BlogDetailsDto>>(_blogDal.GetBlogDetails().OrderByDescending(x => x.BlogId).Skip(skipCount - 6).Take(postCount).ToList());
        }
        public IDataResult<List<BlogDetailsDto>> GetByIdDto(int blogId)
        {

            return new SuccesDataResult<List<BlogDetailsDto>>(_blogDal.GetBlogById(blogId).ToList());
        }
        public IDataResult<List<BlogDetailsDto>> GetBlogDetailsActiveDto(int page)
        {
            int postCount = 6;
            int skipCount = page * postCount;

            return new SuccesDataResult<List<BlogDetailsDto>>(_blogDal.GetBlogDetailsActive().OrderByDescending(x => x.BlogId).Skip(skipCount - 6).Take(postCount).ToList());
        }
        public IDataResult<List<BlogDetailsDto>> GetListBySlugDto(string slug)
        {
            

            return new SuccesDataResult<List<BlogDetailsDto>>(_blogDal.GetBlogDetailsBySlug(slug).ToList());
        }
        public IDataResult<List<Blog>> GetListActive(int page)
        {
            int postCount = 6;
            int skipCount = page * postCount;
            return new SuccesDataResult<List<Blog>>(_blogDal.GetAll(x => x.BlogStatus == true).OrderByDescending(x => x.BlogId).Skip(skipCount - 6).Take(postCount).ToList());
        }
      
        public IDataResult<List<Blog>> GetBlogDetailsLast3Post()
        {
            return new SuccesDataResult<List<Blog>>(_blogDal.GetAll(x => x.BlogStatus == true).OrderByDescending(x => x.BlogId).Take(5).ToList(), Messages.PasswordError);
        }
        public decimal GetCount()
        {
            decimal productquantity = (_blogDal.GetAll().GroupBy(x => x.BlogId).Count());
            decimal pagequantity = productquantity / 6;
            pagequantity = Math.Ceiling(pagequantity);
            return pagequantity;
        }
        public decimal GetCountActive()
        {
            decimal productquantity = (_blogDal.GetAll(x => x.BlogStatus == true).GroupBy(x => x.BlogId).Count());
            decimal pagequantity = productquantity / 6;
            pagequantity = Math.Ceiling(pagequantity);
            return pagequantity;
        }
        public decimal GetCountByCategory(int categoryId)
        {
            decimal productquantity = (_blogDal.GetAll(x => x.BlogStatus == true&&x.CategoryId==categoryId).GroupBy(x => x.BlogId).Count());
            decimal pagequantity = productquantity / 6;
            pagequantity = Math.Ceiling(pagequantity);
            return pagequantity;
        }

        public IResult Update(Blog blog)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _blogDal.Update(blog);
            return new SuccesResult(Messages.UserRegistered);
        }
    }
}