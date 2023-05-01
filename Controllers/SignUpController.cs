using FoodAppAPI.Models;
using FoodAppAPI.Models.Requests;
using FoodAppAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public SignUpController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignUp([FromBody] UserSignUpDTO userSignUp)
        {
            UserModel? user = Register(userSignUp);

            if (user != null)
            {
                string token = Generate(user);
                return Ok(token);
            }

            return NotFound("Registration failed");
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("id", user.Id)
            };

            var token = new JwtSecurityToken
            (
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel? Register(UserSignUpDTO userSignUp)
        {
            UserModel? currentUser = _userService.GetByUsername(userSignUp.Username);

            if (currentUser == null)
            {
                UserModel newUser = new UserModel
                {
                    Username = userSignUp.Username,
                    Email = userSignUp.Email,
                    FirstName = userSignUp.FirstName,
                    Password = userSignUp.Password,
                    Address = userSignUp.Address,
                    Coordinate = userSignUp.Coordinate,
                    LastName = userSignUp.LastName,
                    PhoneNumber = userSignUp.PhoneNumber,
                    Role = userSignUp.Role,
                };

                if (newUser.Role != "Rider" && newUser.Role != "Customer")
                {
                    return null;
                }

                return _userService.Create(newUser);
            }

            return null;
        }
    }
}
