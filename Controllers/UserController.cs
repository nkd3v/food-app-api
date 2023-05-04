using FoodAppAPI.Models;
using FoodAppAPI.Models.Requests;
using FoodAppAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public ActionResult<List<UserModel>> Get()
        {
            return _userService.Get();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(string id)
        {
            return _userService.Get(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<UserModel> Post([FromBody] UserModel user)
        {
            return _userService.Create(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _userService.Delete(id);
        }

        private UserModel? GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value ?? String.Empty,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value ?? String.Empty,
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value ?? String.Empty,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value ?? String.Empty,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value ?? String.Empty,
                    Id = userClaims.FirstOrDefault(o => o.Type == "id")?.Value ?? String.Empty
                };
            }

            return null;
        }

        [Authorize]
        [HttpPost("updatedeliveryinfo")]
        public IActionResult UpdateUserDeliveryInfo([FromBody] UserDeliveryInfoDTO userDeliveryInfo)
        {
            UserModel? user = GetCurrentUser();
            if (user == null || userDeliveryInfo == null)
            {
                return BadRequest();
            }

            var result = _userService.UpdateDeliveryInfo(user.Id, userDeliveryInfo);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(userDeliveryInfo);
        }
    }
}
