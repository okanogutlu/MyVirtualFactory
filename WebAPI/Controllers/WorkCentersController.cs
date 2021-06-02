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
    public class WorkCentersController : ControllerBase
    {
        IWorkCenterServices _workCenterServices;

        public WorkCentersController(IWorkCenterServices workCenterServices)
        {
            _workCenterServices = workCenterServices;
        }


        [SecuredOperation("personel")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _workCenterServices.GetAll();
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
            var result = _workCenterServices.GetByID(ID);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(WorkCenter workCenter)
        {

            var result = _workCenterServices.Update(workCenter);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }


        [SecuredOperation("personel")]
        [HttpPost("add")]
        public IActionResult Add(WorkCenter workCenter)
        {
            var result = (_workCenterServices.Add(workCenter));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }


        [SecuredOperation("personel,customer")]
        [HttpPost("changeactivestatus")]
        public IActionResult ChangeActiveStatus(WorkCenter workCenter, bool ActiveStatus)
        {
            var result = (_workCenterServices.ChangeActiveStatus(workCenter,ActiveStatus));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }
    }
}
