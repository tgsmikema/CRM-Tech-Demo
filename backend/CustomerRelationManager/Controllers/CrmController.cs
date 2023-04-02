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
    // controller class, that can be thought of sub-route of the node+express.
    // enable CORS for this controller
    [EnableCors("_myAllowSpecificOrigins")]
    // this controller specifies route to "https://localhost:8080/api/"
    [Route("api")]
    [ApiController]
    public class CrmController : Controller
    {
        private readonly ICrmRepo _repository;

        public CrmController(ICrmRepo repository)
        {
            _repository = repository;
        }

        // demo GET endpoint that returns plain text of "Testing Endpoint!"
        // the route is subsequently "https://localhost:8080/api/testing"
        [HttpGet("testing")]
        public ActionResult testingFunction()
        {
            return Ok("Testing Endpoint!");
        }

        // to use this endpoint, authentication is required.
        // and the policy is all users which means both user and admin can
        // access this endpoint with a valid login.
        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AllUsers")]
        [HttpGet("login")]
        public ActionResult<UserLoginOutDto> userLogin()
        {
            // retrieve the username of the logged in user throught
            // the claims identity which is explained in the AuthHandler class.

            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();

            string userName = "";
            if (ci.FindFirst("admin") != null)
            {
                userName = ci.FindFirst("admin").Value;
            }
            else if (ci.FindFirst("user") != null)
            {
                userName = ci.FindFirst("user").Value;
            }

            // return a status code 200 and a payload of <UserLoginOutDto> DTO type in JSON format.
            return Ok(_repository.GetUserLoginOutDto(userName));

        }

        // POST method for regietering a User, no authentication required
        [HttpPost("registerUser")]
        // require the request body contains a <UserRegisterInDto> type of object in JSON format.
        public ActionResult userRegister(UserRegisterInDto userRegisterInDto)
        {
            bool isRegisterSuccessful = _repository.AddNewUser(userRegisterInDto);

            if (isRegisterSuccessful)
            {
                return Ok("User successfully registered.");
            }
            else
            {
                // if not registered successfully, return a 404 status and the following message.
                return NotFound("Username not available. Please Try again.");
            }
        }

        // to use this endpoint, authentication is required.
        // and the policy is admin which means only ADMIN can access this endpoint.
        // access this endpoint with a valid admin login.
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
                return NotFound("Username not available. Please Try again.");
            }
        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AllUsers")]
        [HttpGet("allCustomers")]
        public ActionResult<IEnumerable<Customer>> retrieveAllCustomers()
        {
            UserLoginOutDto userInfo = receiveLoggedInUserInfo();

            return Ok(_repository.GetCustomerOutDtoList(userInfo.Id, userInfo.UserType));

        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AllUsers")]
        [HttpPost("addNewCustomer")]
        public ActionResult addNewCustomer(CustomerInDto customerInDto)
        {
            UserLoginOutDto userInfo = receiveLoggedInUserInfo();

            bool isAddingNewCustomerSuccessful = _repository.AddNewCustomer(customerInDto, userInfo.Id);

            if (isAddingNewCustomerSuccessful)
            {
                return Ok("Customer Successfully Added");
            }
            else
            {
                return NotFound("Adding new Customer is failed, please try again");
            }

        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AllUsers")]
        [HttpGet("deleteCustomer")]
        // for simple parameter like this endpoint, a query string is required for the input
        // for example: "https://localhost:8080/api/deleteCustomer?customerId=5"
        public ActionResult deleteCustomer(int customerId)
        {
            UserLoginOutDto userInfo = receiveLoggedInUserInfo();

            bool isAddingNewCustomerSuccessful = _repository.DeleteCustomer(customerId);

            if (isAddingNewCustomerSuccessful)
            {
                return Ok("Customer Successfully Deleted");
            }
            else
            {
                return NotFound("Deletion failed.. please try again.");
            }

        }



        //----------------------------------Helper Methods Below------------------------------------------
        private UserLoginOutDto receiveLoggedInUserInfo()
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();

            string userName = "";
            if (ci.FindFirst("admin") != null)
            {
                userName = ci.FindFirst("admin").Value;
            }
            else if (ci.FindFirst("user") != null)
            {
                userName = ci.FindFirst("user").Value;
            }

            UserLoginOutDto userInfo = _repository.GetUserLoginOutDto(userName);

            return userInfo;
        }


    }
}
