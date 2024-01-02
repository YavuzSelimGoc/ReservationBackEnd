using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetList();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallActive")]
        public IActionResult GetAllActive()
        {
            var result = _categoryService.GetListActive();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            category.CategoryStatus = true;
            var result = _categoryService.Add(category);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("ard")]
        public IActionResult Ard( string description,string categoryName)
        {

            Category category = new Category();
            category.CategoryName = categoryName;
            category.CategoryDescription = description;
            category.CategoryStatus = true;
            var result = _categoryService.Add(category);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Category category)
        {

            var result = _categoryService.Delete(category);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("passive")]
        public IActionResult Passive(Category category)
        {
            category.CategoryStatus = false;
            var result = _categoryService.Update(category);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("active")]
        public IActionResult Active(Category category)
        {
            category.CategoryStatus = true;
            var result = _categoryService.Update(category);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}