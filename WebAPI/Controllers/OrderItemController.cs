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
    public class OrderItemController : ControllerBase
    {
        IOrderItemServices _IOrderItemServices;

        public OrderItemController(IOrderItemServices ıOrderItemServices)
        {
            _IOrderItemServices = ıOrderItemServices;
        }

        [SecuredOperation("personel")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _IOrderItemServices.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [SecuredOperation("personel")]
        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _IOrderItemServices.GetByID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(OrderItem order)
        {

            var result = _IOrderItemServices.Update(order);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("add")]
        public IActionResult Add(OrderItem order)
        {
            var result = (_IOrderItemServices.Add(order));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }

        [SecuredOperation("personel")]
        [HttpGet("getbyorderid")]
        public IActionResult GetByOrderID(int OrderID)
        {
            var result = _IOrderItemServices.GetByOrderID(OrderID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getbyproductid")]
        public IActionResult GetByProductID(int ProductID)
        {
            var result = _IOrderItemServices.GetByProductID(ProductID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getorderitemdetails")]
        public IActionResult GetGetOrderItemDetailsll()
        {
            var result = _IOrderItemServices.GetOrderItemDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getorderitemdetailsbyorderid")]
        public IActionResult GetOrderItemDetailsByOrderID(int OrderID)
        {
            var result = _IOrderItemServices.GetOrderItemDetailsByOrderID(OrderID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        
        [SecuredOperation("personel,customer")]
        [HttpGet("getorderitemdetailsbyorderid")]
        public IActionResult GetOrderItemDetailsByOrderItemID(int OrderItemID)
        {
            var result = _IOrderItemServices.GetOrderItemDetailsByOrderItemID(OrderItemID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
