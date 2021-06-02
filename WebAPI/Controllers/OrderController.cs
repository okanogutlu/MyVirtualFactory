using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderServices.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



       
        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _orderServices.GetByID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(Order order)
        {

            var result = _orderServices.Update(order);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = (_orderServices.Add(order));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }

        [SecuredOperation("personel")]
        [HttpGet("getalldeadlineuntilnow")]
        public IActionResult GetAllDeadLineUntilNow(DateTime deadline)
        {
            var result = _orderServices.GetAllDeadLineUntilNow(deadline);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getAllorderdateuntilnow")]
        public IActionResult GetAllOrderDateUntilNow(DateTime orderDate)
        {
            var result = _orderServices.GetAllDeadLineUntilNow(orderDate);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerID(int ID)
        {
            var result = _orderServices.GetByCustomerID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getbyorderdate")]
        public IActionResult GetByOrderDate(DateTime orderDate)
        {
            var result = _orderServices.GetByOrderDate(orderDate);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getbyorderdeadline")]
        public IActionResult GetByOrderDeadline(DateTime orderDeadline)
        {
            var result = _orderServices.GetByOrderDate(orderDeadline);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getorderdetails")]
        public IActionResult GetOrderDetails()
        {
            var result = _orderServices.GetOrderDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getorderdetailsbycustomerid")]
        public IActionResult GetOrderDetailsByCustomerID(int ID)
        {
            var result = _orderServices.GetOrderDetailsByCustomerID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [SecuredOperation("personel,customer")]
        [HttpGet("getorderdetailsbyorderid")]
        public IActionResult GetOrderDetailsByOrderID(int ID)
        {
            var result = _orderServices.GetOrderDetailsByOrderID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

    }
}


