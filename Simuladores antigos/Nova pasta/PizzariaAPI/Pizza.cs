namespace PizzariaAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Sabor { get; set; } = string.Empty;
        public int TempoPreparo { get; set; }
    }
}
