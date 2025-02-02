using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzariaAPI.Models;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return BadRequest(new { message = "Usuário e senha são obrigatórios." });

            // Usuários fixos para teste
            var validUsers = new List<User>
            {
                new User { Username = "garcom", Password = "1234" },
                new User { Username = "cozinheiro", Password = "1234" }
            };

            var validUser = validUsers.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (validUser == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = GenerateToken(validUser.Username);
            return Ok(new { token });
        }

        private string GenerateToken(string role)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            Console.WriteLine($"🔑 Chave Secreta: {secretKey}"); // Apenas para teste


            if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
            {
                throw new ArgumentException("A chave secreta precisa ter pelo menos 32 caracteres.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
