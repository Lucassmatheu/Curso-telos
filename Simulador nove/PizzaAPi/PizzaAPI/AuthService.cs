using Microsoft.IdentityModel.Tokens;
using PizzaAPI.Modelos;
using System.Security.Claims;
using System.Text;

namespace PizzariaAPI
{
    public class AuthService // Colocando dentro de uma classe
    {
        public static SecurityTokenDescriptor CreateTokenDescriptor(User usuario, string chaveSecreta)
        {
            var key = Encoding.ASCII.GetBytes(chaveSecreta);

            return new SecurityTokenDescriptor
            {
                // Corrigido ClaimTypes.Name (não "Username")
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),  // Assumindo que "Nome" é a propriedade no modelo User
                   
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
        }
    }
}
