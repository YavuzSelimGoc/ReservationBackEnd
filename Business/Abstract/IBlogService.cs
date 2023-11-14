using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface IBlogService
	{

        IDataResult<Blog> GetById(int blogId);
        IDataResult<List<BlogDetailsDto>> GetByIdDto(int blogId);
        IDataResult<Blog> GetBySlug(string slug);
        IDataResult<List<Blog>> GetList();
        IDataResult<List<BlogDetailsDto>> GetListByCategoryDto(int categoryId,int page);
        IDataResult<List<BlogDetailsDto>> GetListBySlugDto(string slug);
        IDataResult<List<Blog>> GetListActive(int page);
        IResult Add(Blog blog);
        decimal GetCount();
        decimal GetCountActive();
        decimal GetCountByCategory(int categoryId);
        IDataResult<List<BlogDetailsDto>> GetBlogDetailsDto(int page);
        IDataResult<List<BlogDetailsDto>> GetBlogDetailsActiveDto(int page);
        IDataResult<List<Blog>> GetBlogDetailsLast3Post();
        IResult Delete(Blog blog);
        IResult Update(Blog blog);
    }
}

