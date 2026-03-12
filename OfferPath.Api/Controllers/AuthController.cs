using Microsoft.AspNetCore.Mvc;
using OfferPath.Api.Data;
using OfferPath.Api.Dtos;
using OfferPath.Api.Models;

namespace OfferPath.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (existingUser != null)
            {
                return BadRequest("Email already exists.");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == dto.Email && x.PasswordHash == dto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(new
            {
                user.Id,
                user.Name,
                user.Email
            });
        }
    }
}