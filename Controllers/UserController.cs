using FoodAppAPI.Models;
using FoodAppAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<UserModel> Post([FromBody] UserModel order)
        {
            return _userService.Create(order);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _userService.Delete(id);
        }
    }
}
