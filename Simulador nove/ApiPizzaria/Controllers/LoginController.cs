using ApiPizzaria.Modelo;
using ApiPizzaria.Service;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Modelos;

namespace ApiPizzaria.Controllers
{
    [ApiController] // ✅ CORRETO: A anotação está na classe
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        [HttpPost] // ✅ Adicionando o método HTTP correto
        public IActionResult Login([FromBody] UsuarioRequest usuarioRequest)
        {
            var usuario = UsuarioRepository.Get(usuarioRequest.nome, usuarioRequest.PasswordHash);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            var token = TokenService.GenerateToken(usuario);

            usuario.PasswordHash = "";

            return Ok(new
            {
                usuario = usuario,
                token = token
            });
        }
    }
}
