using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserServices _userService;

        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        [SecuredOperation("personel,customer")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("update")]
        public IActionResult Update(User user)
        {

            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = (_userService.Add(user));
            if (result.Success)
            {
                return Ok(result.Success);
            }

            return BadRequest(result.Message);

        }

        [SecuredOperation("personel")]
        [HttpPost("getbyemail")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetByMailForApi(email);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpPost("getordersbyuser")]
        public IActionResult GetOrders(User user)
        {
            var result = _userService.GetOrders(user);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel")]
        [HttpPost("getclaimsbyuser")]
        public IActionResult GetClaimsForApi(User user)
        {
            var result = _userService.GetClaimsForApi(user);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [SecuredOperation("personel")]
        [HttpPost("getcustomers")]
        public IActionResult GetCustomers()
        {
            var result = _userService.GetCustomers();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [SecuredOperation("personel,customer")]
        [HttpPost("updateuserprofile")]
        public IActionResult UpdateUserProfile(UpdateUserProfileDto updateUserProfileDto)
        {
            _userService.UpdateUserProfile(updateUserProfileDto);
                return Ok();
        }

    }
}
