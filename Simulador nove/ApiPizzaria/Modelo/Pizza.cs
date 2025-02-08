using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPizzaria.Modelos
{
    public class Pizza
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       // public decimal Preco { get; set; }

        [Required]
        public string Sabor { get; internal set; }
        public decimal TempoPreparo { get; internal set; }
    }
}
