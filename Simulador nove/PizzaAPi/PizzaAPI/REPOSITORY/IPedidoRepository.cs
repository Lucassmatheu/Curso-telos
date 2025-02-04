using PizzaAPI.Request;
using PizzariaAPI;
using PizzaAPI.Modelos;


public interface IPedidoRepository
{
    Pedidos Add(PedidoRequest pedidoRequest);
    Pedidos Update(int id, PedidoRequest pedidoRequest);
    Pedidos Get(int id);
    IEnumerable<Pedidos> GetAll();
    void Delete(int id);
}
