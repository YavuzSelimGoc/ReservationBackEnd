using System;
using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Abstract
{
	public interface IBlogDal : IEntityRepository<Blog>
    {
        List<BlogDetailsDto> GetBlogDetails();
        List<BlogDetailsDto> GetBlogById(int blogId);
        List<BlogDetailsDto> GetBlogDetailsActive();
        List<BlogDetailsDto> GetBlogDetailsBySlug(string slug);
        List<BlogDetailsDto> GetBlogDetailsByCategoryId(int categoryId);
    }
}