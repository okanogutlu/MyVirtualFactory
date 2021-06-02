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
    public class SubProductTreesController : ControllerBase
    {
        ISubProductTreeServices _subProductTreeServices;

        public SubProductTreesController(ISubProductTreeServices subProductTreeServices)
        {
            _subProductTreeServices = subProductTreeServices;
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _subProductTreeServices.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(SubProductTree subProductTree)
        {

            var result = _subProductTreeServices.Update(subProductTree);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("add")]
        public IActionResult Add(SubProductTree subProductTree)
        {
            var result = (_subProductTreeServices.Add(subProductTree));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }


        [SecuredOperation("personel")]
        [HttpGet("getallbyproductid")]
        public IActionResult GetByAllByProductID(int ID)
        {
            var result = _subProductTreeServices.GetAllByProductID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getbysubproductid")]
        public IActionResult GetBySubProductID(int ID)
        {
            var result = _subProductTreeServices.GetBySubProductID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getamount")]
        public IActionResult GetAmount(int SubProductID, int ProductID)
        {
            var result = _subProductTreeServices.GetAmount(SubProductID,ProductID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getsubproducttreedetails")]
        public IActionResult GetSubProductTreeDetails()
        {
            var result = _subProductTreeServices.GetSubProductTreeDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getsubproducttreedetailsbyid")]
        public IActionResult GetSubProductTreeDetailsByID(int ID)
        {
            var result = _subProductTreeServices.GetSubProductTreeDetailsByID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getsubproducttreedetailsbyproductname")]
        public IActionResult GetSubProductTreeDetailsByProductName(string productName)
        {
            var result = _subProductTreeServices.GetSubProductTreeDetailsByProductName(productName);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


       
    }
}
