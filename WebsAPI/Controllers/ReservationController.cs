using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _reservationService.GetList();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByUserNameForCustomer")]
        public IActionResult GetByUserNameForCustomer(string userName)
        {
            var result = _reservationService.GetListByUserNameForCustomer(userName);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByUserNameForCustomerActive")]
        public IActionResult GetByUserNameForCustomerActive(string userName)
        {
            var result = _reservationService.GetListByUserNameForCustomerActive(userName);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByUserNameForBusiness")]
        public IActionResult GetByUserNameForBusiness(string userName)
        {
            var result = _reservationService.GetListByUserNameForBusiness(userName);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByUserNameForBusinessActive")]
        public IActionResult GetByUserNameForBusinessActive(string userName)
        {
            var result = _reservationService.GetListByUserNameForBusinessActive(userName);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallActive")]
        public IActionResult GetAllActive()
        {
            var result = _reservationService.GetListActive();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Reservation reservation)
        {
            reservation.ReservationStatus = true;
            reservation.isAccept = true;
            var result = _reservationService.Add(reservation);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _reservationService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Reservation reservation)
        {
            var result = _reservationService.Update(reservation);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Reservation reservation)
        {

            var result = _reservationService.Delete(reservation);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("passive")]
        public IActionResult Passive(Reservation reservation)
        {
            reservation.isAccept = false;
            reservation.ReservationStatus = false;
            var result = _reservationService.Update(reservation);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("active")]
        public IActionResult Active(Reservation reservation)
        {
            reservation.isAccept = true;
            reservation.ReservationStatus = false;
            var result = _reservationService.Update(reservation);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}