using System;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _blogService.GetList();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetByCategoryIdDto")]
        public IActionResult GetByCategoryId(int categoryId,int page)
        {
            var result = _blogService.GetListByCategoryDto(categoryId,page);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getCount")]
        public IActionResult GetCount()
        {
            decimal result = _blogService.GetCount();
            return Ok(result);
        }
        [HttpGet("getCountActive")]
        public IActionResult GetCountActive()
        {
            decimal result = _blogService.GetCount();
            return Ok(result);
        }
        [HttpGet("getCountByCategory")]
        public IActionResult getCountByCategory(int categoryId)
        {
            decimal result = _blogService.GetCountByCategory(categoryId);
            return Ok(result);
        }
        [HttpGet("getlast3post")]
        public IActionResult GetLast3Post()
        {
            var result = _blogService.GetBlogDetailsLast3Post();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallActive")]
        public IActionResult GetAllActive(int page)
        {
            var result = _blogService.GetListActive(page);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getBlogDto")]
        public IActionResult GetAllDto(int page)
        {
            var result = _blogService.GetBlogDetailsDto(page);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getBlogActiveDto")]
        public IActionResult GetAllActiveDto(int page)
        {
            var result = _blogService.GetBlogDetailsActiveDto(page);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Blog blog)
        {
            blog.BlogDate = DateTime.Parse(DateTime.Now.ToString("dd'/'MM'/'yyyy"));
            blog.BlogStatus = true;
            var result = _blogService.Add(blog);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _blogService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdDto")]
        public IActionResult GetByIdDto(int id)
        {
            var result = _blogService.GetByIdDto(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("GetBySlugDto")]
        public IActionResult GetBySlugDto(string slug)
        {
            var result = _blogService.GetListBySlugDto(slug);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetBySlug")]
        public IActionResult GetBySlug(string slug)
        {
            var result = _blogService.GetBySlug(slug);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Blog blog)
        {
            var result = _blogService.Update(blog);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Blog blog)
        {

            var result = _blogService.Delete(blog);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("passive")]
        public IActionResult Passive(Blog blog)
        {
            blog.BlogStatus = false;
            var result = _blogService.Update(blog);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("active")]
        public IActionResult Active(Blog blog)
        {
            blog.BlogStatus = true;
            var result = _blogService.Update(blog);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}