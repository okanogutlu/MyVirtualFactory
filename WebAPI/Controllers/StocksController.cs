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
    public class StocksController : ControllerBase
    {
        IStockServices _stockServices;

        public StocksController(IStockServices stockServices)
        {
            _stockServices = stockServices;
        }

        [SecuredOperation("personel")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _stockServices.GetAll();
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
            var result = _stockServices.GetByID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(Stock stock)
        {

            var result = _stockServices.Update(stock);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("add")]
        public IActionResult Add(Stock stock)
        {
            var result = (_stockServices.Add(stock));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getbyproductid")]
        public IActionResult GetByProductID(int productID)
        {
            var result = _stockServices.GetByProductID(productID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
