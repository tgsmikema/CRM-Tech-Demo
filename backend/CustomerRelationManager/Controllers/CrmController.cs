using Microsoft.AspNetCore.Mvc;
using CustomerRelationManager.Data;
using CustomerRelationManager.Dtos;
using CustomerRelationManager.Model;
using Microsoft.AspNetCore.Authorization;

namespace CustomerRelationManager.Controllers
{
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
    }
}
