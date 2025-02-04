using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaAPI.Modelos
{
    public class User
    {

        [Key] // ✅ Define o Id como chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Nome { get; set; } // Adicionando Username
        public required string Password { get; set; } // Adicionando Password (somente para login)
        public string Role { get; set; }




    }
}

