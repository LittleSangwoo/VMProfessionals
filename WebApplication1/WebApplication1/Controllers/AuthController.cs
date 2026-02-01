using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly VmpContext _db;
        private readonly IConfiguration _cfg;

        public AuthController(VmpContext db, IConfiguration cfg)
        {
            _cfg = cfg;
            _db = db;
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdStr == null)
                return BadRequest();
            var user = _db.Users.Include(u => u.IdRoleNavigation).FirstOrDefault(u => u.IdUser == userIdStr);
            var roleName = user.IdRoleNavigation.Role1 ?? "Unknown";
            return Ok(new
            {
                idUser = userIdStr,
                surname = user.Surname,
                name = user.Name,
                patronymic = user.Patronymic,
                email = user.Email,
                role = roleName
            });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
                return Unauthorized(new { message = "Пароль и имейл должны быть введены" });
            var user = _db.Users.Include(u => u.IdRoleNavigation).FirstOrDefault(u => u.Email == req.Email);
             if (user == null || user.Password !=  req.Password)
                return Unauthorized(new { message = "Пароль и (или) имейл не совпадают" });
            var roleName = user.IdRoleNavigation.Role1 ?? "Unknown";
            var token = CreateToken(user.IdUser, user.Email, roleName);

            return Ok(new
            {
                accessToken = token,
                tokenType = "Bearer"
            });
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] LoginRequest req)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if(userEmail == null || userEmail == null)
                return BadRequest();

            var token = CreateToken(userIdStr, userEmail, userRole);

            return Ok(new
            {
                accessToken = token,
                tokenType = "Bearer"
            });
        }

        public string CreateToken(string idUser, string email, string role)
        {
            var jwt = _cfg.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, idUser),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
            };
            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwt["Minutes"]!)),
                signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
