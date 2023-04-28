using FoodAppAPI.Models;
using FoodAppAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: api/<MenuController>
        [HttpGet]
        public ActionResult<List<Menu>> Get()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Console.WriteLine(User.FindFirst(ClaimTypes.Email)?.Value);
            Console.WriteLine(User.FindFirst(ClaimTypes.GivenName)?.Value);
            Console.WriteLine(User.FindFirst(ClaimTypes.Surname)?.Value);
            Console.WriteLine(User.FindFirst(ClaimTypes.Role)?.Value);
            return _menuService.Get();
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public ActionResult<Menu> Get(string id)
        {
            return _menuService.Get(id);
        }

        // POST api/<MenuController>
        [HttpPost]
        public ActionResult<Menu> Post([FromBody] Menu menu)
        {
            return _menuService.Create(menu);
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _menuService.Delete(id);
        }
    }
}
