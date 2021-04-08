using HumanResource.Core.Models;
using HumanResource.Core.Services;
using HumanResource.Core.Services.Interfaces;
using HumanResource.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HumanResource.WebApi.Controllers
{
    [Route("HR/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext applicationContext;
        private readonly IUserService userService;

        public UserController(ApplicationContext context)
        {
            applicationContext = context;
            userService = new UserService(applicationContext);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRequestModel userRequest)
        {
            var response = userService.SaveUser(userRequest);

            if (response.ErrorMessage.Count > 0)
            {
                return BadRequest(string.Join(Environment.NewLine, response.ErrorMessage));
            }

            return Ok(response.ErrorMessage);
        }

        [HttpGet]
        public object Get(string name)
        {
            var response = userService.GetUserByName(name);
            return Ok(response);
        }
    }
}
