using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Entities.Concrete;
using Entities.Concrete.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductServices _ProductService;

        public ProductsController(IProductServices productService)
        {
            _ProductService = productService;
        }

        [SecuredOperation("personel")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ProductService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [SecuredOperation("personel,customer")]
        [HttpGet("getbyid")]
        public IActionResult GetByID(int ID)
        {
            var result = _ProductService.GetByID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(Product Product)
        {

            var result = _ProductService.Update(Product);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("add")]
        public IActionResult Add(Product Product)
        {
            var result = (_ProductService.Add(Product));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getbyproductname")]
        public IActionResult GetByProductName(string productName)
        {
            var result = _ProductService.GetByProductName(productName);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getbyproducttype")]
        public IActionResult GetByProductType(string ProductType)
        {
            ProductTypes productType = (ProductTypes)System.Enum.Parse(typeof(ProductTypes), ProductType);
            var result = _ProductService.GetByProductType(productType);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getsalableproducts")]
        public IActionResult GetSalableProducts()
        {
            var result = _ProductService.GetSalableProducts();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
