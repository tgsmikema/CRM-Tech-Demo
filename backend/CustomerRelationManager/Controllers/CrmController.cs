using Microsoft.AspNetCore.Mvc;
using CustomerRelationManager.Data;
using CustomerRelationManager.Dtos;
using CustomerRelationManager.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;

namespace CustomerRelationManager.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api")]
    [ApiController]
    public class CrmController : Controller
    {
        private readonly ICrmRepo _repository;

        public CrmController(ICrmRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("testing")]
        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult testingFunction()
        {
            return Ok("Testing Endpoint!");
        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AllUsers")]
        [HttpGet("login")]
        public ActionResult<UserLoginOutDto> userLogin()
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();

            string userName = "";
            if (ci.FindFirst("admin") != null)
            {
                userName = ci.FindFirst("admin").Value;
            }
            else if (ci.FindFirst("user") != null)
            {
                userName = ci.FindFirst("vet").Value;
            }    

            return Ok(_repository.GetUserLoginOutDto(userName));

        }

        [HttpPost("registerUser")]
        public ActionResult userRegister(UserRegisterInDto userRegisterInDto)
        {
            bool isRegisterSuccessful = _repository.AddNewUser(userRegisterInDto);

            if (isRegisterSuccessful)
            {
                return Ok("User successfully registered.");
            }
            else
            {
                return Ok("Username not available. Please Try again.");
            }
        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AdminOnly")]
        [HttpPost("registerAdmin")]
        public ActionResult adminRegister(UserRegisterInDto userRegisterInDto)
        {
            bool isRegisterSuccessful = _repository.AddNewAdmin(userRegisterInDto);

            if (isRegisterSuccessful)
            {
                return Ok("Admin successfully registered.");
            }
            else
            {
                return Ok("Username not available. Please Try again.");
            }
        }


    }
}
