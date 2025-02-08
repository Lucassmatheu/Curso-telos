using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ApiPizzaria.Modelos
{
    public class Usuario
    {
      
    
        public  int Id { get; set; }

        public required string Nome { get; set; }
        

        public required string PasswordHash { get; set; }


        public required string Role { get; set; }
    }
}
