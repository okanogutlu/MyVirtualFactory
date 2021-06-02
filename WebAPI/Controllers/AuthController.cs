using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthServices _authService;
        private IUserServices _userService;
        private IOrderServices _orderService;

        public AuthController(IAuthServices authService,IUserServices userService,IOrderServices orderService)
        {
            _authService = authService;
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet("deneme")]
        public ActionResult Deneme()
        {


            //var result = _orderService.Add(new Entities.Concrete.Order
            //{
            //    Deadline = new DateTime(2030, 12, 31),
            //    OrderDate = new DateTime(2021, 02, 02),
            //    UserID = _userService.GetByMail("okan@gmail.com").ID
            //}) ;
            //_userService.Add(new Core.Entities.Concrete.User
            //{
            //    Email="okan@gmail.com",
            //    FirstName="Okan",
            //    LastName="Ogutlu",
            //    PasswordHash = Encoding.ASCII.GetBytes("deneme"),
            //    Status=true

            //});
            var user = _userService.GetByMail("okan@gmail.com");
            var orders = _orderService.GetByCustomerID(1);
            return Ok();
        }


        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getactiveuser")]
        public IActionResult ActiveUser(string email)
        {
           
                var user = _userService.GetByUserName(email);
                ActiveUserDTO activeUser = new ActiveUserDTO()
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    Claims = _userService.GetClaims(user),
                    ID =user.ID,
                    Email=user.Email

                };
                return Ok(activeUser);
            
            
        }
    }
}
