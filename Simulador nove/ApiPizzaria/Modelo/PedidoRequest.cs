namespace ApiPizzaria.Modelo
{
    public class PedidoRequest
    {
        public string ClienteNome { get; set; }
        public List<int> PizzaIds { get; set; }
    }
}

