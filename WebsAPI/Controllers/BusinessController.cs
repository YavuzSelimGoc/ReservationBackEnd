using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        IBusinessService _BusinessService;

        public BusinessController(IBusinessService BusinessService)
        {
            _BusinessService = BusinessService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _BusinessService.GetList();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByUserName")]
        public IActionResult GetByUserName(string userName)
        {
            var result = _BusinessService.GetListByUserName(userName);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallActive")]
        public IActionResult GetAllActive()
        {
            var result = _BusinessService.GetListActive();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getBusinessDto")]
        public IActionResult GetAllDto()
        {
            var result = _BusinessService.GetBusinessDetailsDto();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetByCategoryIdDto")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _BusinessService.GetBusinessDetailsDtoByCategoryId(categoryId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getBusinessActiveDto")]
        public IActionResult GetAllActiveDto()
        {
            var result = _BusinessService.GetBusinessDetailsActiveDto();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Entities.Concrete.Business Business)
        {
            Business.BusinessStatus = true;
            var result = _BusinessService.Add(Business);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _BusinessService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Entities.Concrete.Business Business)
        {
            var result = _BusinessService.Update(Business);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Entities.Concrete.Business Business)
        {

            var result = _BusinessService.Delete(Business);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("passive")]
        public IActionResult Passive(Entities.Concrete.Business Business)
        {
            Business.BusinessStatus = false;
            var result = _BusinessService.Update(Business);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("active")]
        public IActionResult Active(Entities.Concrete.Business Business)
        {
            Business.BusinessStatus = true;
            var result = _BusinessService.Update(Business);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}