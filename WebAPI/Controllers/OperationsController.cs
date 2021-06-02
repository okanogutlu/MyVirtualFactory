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
    public class OperationsController : ControllerBase
    {
        IOperationServices _operationService;

        public OperationsController(IOperationServices operationService)
        {
            _operationService = operationService;
        }



        [SecuredOperation("personel,customer")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _operationService.GetAll();
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
            var result = _operationService.GetByID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getbyproducttype")]
        public IActionResult GetByProductType(string productType)
        {
            ProductTypes type = (ProductTypes)System.Enum.Parse(typeof(ProductTypes), productType);

            var result = _operationService.GetByProductType(type);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(Operation operation)
        {

            var result = _operationService.Update(operation);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("add")]
        public IActionResult Add(Operation operation)
        {
            var result=(_operationService.Add(operation));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }

    }
}
