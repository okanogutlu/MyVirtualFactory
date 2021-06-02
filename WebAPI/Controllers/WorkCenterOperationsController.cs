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
    public class WorkCenterOperationsController : ControllerBase
    {
        IWorkCenterOperationServices _workCenterOperationServices;

        public WorkCenterOperationsController(IWorkCenterOperationServices workCenteroperationServices)
        {
            _workCenterOperationServices = workCenteroperationServices;
        }


        [SecuredOperation("personel")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _workCenterOperationServices.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [SecuredOperation("personel")]
        [HttpGet("getbyoperationid")]
        public IActionResult GetByOperationID(int ID)
        {
            var result = _workCenterOperationServices.GetByOperationID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [SecuredOperation("personel")]
        [HttpGet("getbyworkcenterid")]
        public IActionResult GetByWorkCenterID(int ID)
        {
            var result = _workCenterOperationServices.GetByWorkCenterID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getbyworkcenteroperationid")]
        public IActionResult GetByWorkCenterOperationID(int ID)
        {
            var result = _workCenterOperationServices.GetByWorkCenterOperationID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [SecuredOperation("personel")]
        [HttpGet("getworkcenteroperationdetails")]
        public IActionResult GetWorkCenterOperationDetails()
        {
            var result = _workCenterOperationServices.GetWorkCenterOperationDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getworkcenteroperationdetailsbyworkcentername")]
        public IActionResult GetWorkCenterOperationDetailsbyWorkCenterName(string workCenterName)
        {
            var result = _workCenterOperationServices.GetWorkCenterOperationDetailsbyWorkCenterName(workCenterName);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpGet("getworkcenteroperationdetailsbyoperationname")]
        public IActionResult GetWorkCenterOperationDetailsByOperationName(string operationName)
        {
            var result = _workCenterOperationServices.GetWorkCenterOperationDetailsByOperationName(operationName);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [SecuredOperation("personel")]
        [HttpGet("getworkcenteroperationdetailsproducttype")]
        public IActionResult GetWorkCenterOperationDetailsByProductType(string ProductType)
        {
            var result = _workCenterOperationServices.GetWorkCenterOperationDetailsByProductType(ProductType);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(WorkCenterOperation workCenterOperation)
        {

            var result = _workCenterOperationServices.Update(workCenterOperation);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }


        [SecuredOperation("personel")]
        [HttpPost("add")]
        public IActionResult Add(WorkCenterOperation workCenterOperation)
        {
            var result = (_workCenterOperationServices.Add(workCenterOperation));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }


    }
}


