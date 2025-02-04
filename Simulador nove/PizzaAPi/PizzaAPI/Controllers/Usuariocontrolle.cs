using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PizzaAPI.Modelos;
using PizzaAPI.Context;
using Microsoft.EntityFrameworkCore; // Para acessar o DbContext
using Microsoft.AspNetCore.Identity; // Para PasswordHasher

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuariocontrolle : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly PizzariaContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public Usuariocontrolle(IConfiguration configuration, PizzariaContext context)
        {
            _configuration = configuration;
            _context = context;
            _passwordHasher = new PasswordHasher<User>(); // Inicializando o PasswordHasher
        }

        // Método para realizar login e gerar o token JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginRequest)
        {
            // Validando se o usuário existe no banco de dados
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Nome == loginRequest.Nome);

            if (user == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            // Verificando se a senha informada é válida
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            // Gerar o token JWT
            var token = GenerateJwtToken(user.Nome, user.Role);

            return Ok(new { token });
        }

        // Método para gerar o token JWT
        private string GenerateJwtToken(string nome, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, nome),
                new Claim(ClaimTypes.Role, role) // Atribuindo o papel do usuário
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
