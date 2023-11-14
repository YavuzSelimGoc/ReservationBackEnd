using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfBlogDal : EfRepositoryBase<Blog, BlogContext>, IBlogDal
    {
        public List<BlogDetailsDto> GetBlogDetails()
        {
            using (BlogContext northwindContext = new BlogContext())
            {
                var result = from p in northwindContext.Blog
                             join c in northwindContext.Category
                             on p.CategoryId equals c.CategoryId
                            

                             select new BlogDetailsDto
                             {
                                 BlogId = p.BlogId,
                                 BlogTitle = p.BlogTitle,
                                 CategoryName = c.CategoryName,
                                 CategoryId = p.CategoryId,
                                 BlogContent = p.BlogContent,
                                 BlogWriter = p.BlogWriter,
                                 BlogFaq=p.BlogFaq,
                                 BlogText=p.BlogText,
                                 MetaDescription = p.MetaDescription,
                                 MetaTitle = p.MetaTitle,
                                 BlogTag = p.BlogTag,
                                 BlogImage = p.BlogImage,
                                 BlogDate = p.BlogDate,
                                 BlogStatus = p.BlogStatus,

                                 BlogUrl=p.BlogUrl

                             };
                return result.ToList();
            }

        }
        public List<BlogDetailsDto> GetBlogById(int blogId)
        {
            using (BlogContext northwindContext = new BlogContext())
            {
                var result = from p in northwindContext.Blog
                             join c in northwindContext.Category
                             on p.CategoryId equals c.CategoryId
                             where p.BlogId==blogId

                             select new BlogDetailsDto
                             {
                                 BlogId = p.BlogId,
                                 BlogTitle = p.BlogTitle,
                                 CategoryName = c.CategoryName,
                                 CategoryId = p.CategoryId,
                                 BlogContent = p.BlogContent,
                                 BlogWriter = p.BlogWriter,
                                 BlogText = p.BlogText,
                                 BlogFaq = p.BlogFaq,
                                 MetaDescription = p.MetaDescription,
                                 MetaTitle = p.MetaTitle,
                                 BlogTag = p.BlogTag,
                                 BlogImage = p.BlogImage,
                                 BlogDate = p.BlogDate,
                                 BlogStatus = p.BlogStatus,

                                 BlogUrl = p.BlogUrl

                             };
                return result.ToList();
            }

        }
        public List<BlogDetailsDto> GetBlogDetailsActive()
        {
            using (BlogContext northwindContext = new BlogContext())
            {
                var result = from p in northwindContext.Blog
                             join c in northwindContext.Category
                             on p.CategoryId equals c.CategoryId
                             where p.BlogStatus == true

                             select new BlogDetailsDto
                             {
                                 BlogId = p.BlogId,
                                 BlogTitle = p.BlogTitle,
                                 CategoryName = c.CategoryName,
                                 CategoryId = p.CategoryId,
                                 BlogContent = p.BlogContent,
                                 BlogWriter = p.BlogWriter,
                                 BlogFaq = p.BlogFaq,
                                 BlogText = p.BlogText,
                                 MetaDescription = p.MetaDescription,
                                 MetaTitle = p.MetaTitle,
                                 BlogTag = p.BlogTag,
                                 BlogImage = p.BlogImage,
                                 BlogDate = p.BlogDate,
                                 BlogStatus = p.BlogStatus,

                                 BlogUrl = p.BlogUrl

                             };
                return result.ToList();
            }

        }
        public List<BlogDetailsDto> GetBlogDetailsBySlug(string slug)
        {
            using (BlogContext northwindContext = new BlogContext())
            {
               
                var result = from p in northwindContext.Blog
                             join c in northwindContext.Category
                             on p.CategoryId equals c.CategoryId
                             where p.BlogStatus == true && p.BlogUrl==slug

                             select new BlogDetailsDto
                             {
                                 BlogId = p.BlogId,
                                 BlogTitle = p.BlogTitle,
                                 CategoryName = c.CategoryName,
                                 CategoryId = p.CategoryId,
                                 BlogContent = p.BlogContent,
                                 BlogText = p.BlogText,
                                 BlogFaq = p.BlogFaq,
                                 BlogWriter = p.BlogWriter,
                                 MetaDescription = p.MetaDescription,
                                 MetaTitle = p.MetaTitle,
                                 BlogTag = p.BlogTag,
                                 BlogImage = p.BlogImage,
                                 BlogDate = p.BlogDate,
                                 BlogStatus = p.BlogStatus,

                                 BlogUrl = p.BlogUrl

                             };
                
                return result.ToList();
            }

        }
        public List<BlogDetailsDto> GetBlogDetailsByCategoryId(int categoryId)
        {
            using (BlogContext northwindContext = new BlogContext())
            {

                var result = from p in northwindContext.Blog
                             join c in northwindContext.Category
                             on p.CategoryId equals c.CategoryId
                             where p.BlogStatus == true && p.CategoryId == categoryId

                             select new BlogDetailsDto
                             {
                                 BlogId = p.BlogId,
                                 BlogTitle = p.BlogTitle,
                                 CategoryName = c.CategoryName,
                                 CategoryId = p.CategoryId,
                                 BlogFaq = p.BlogFaq,
                                 BlogContent = p.BlogContent,
                                 BlogWriter = p.BlogWriter,
                                 BlogText = p.BlogText,
                                 MetaDescription = p.MetaDescription,
                                 MetaTitle = p.MetaTitle,
                                 BlogTag = p.BlogTag,
                                 BlogImage = p.BlogImage,
                                 BlogDate = p.BlogDate,
                                 BlogStatus = p.BlogStatus,

                                 BlogUrl = p.BlogUrl

                             };

                return result.ToList();
            }

        }
    }
}

