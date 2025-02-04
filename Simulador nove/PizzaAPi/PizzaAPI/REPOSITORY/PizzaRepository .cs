using PizzaAPI.Modelos;

namespace PizzaAPI.Repository
{
    public interface IPedidoRepository
    {
        Task<Pedidos> Get(int id);
        Task<List<Pedidos>> GetAll();
        Task AddAsync(Pedidos pedido);
        Task UpdateAsync(Pedidos pedido);
        Task DeleteAsync(int id);
    }
}
