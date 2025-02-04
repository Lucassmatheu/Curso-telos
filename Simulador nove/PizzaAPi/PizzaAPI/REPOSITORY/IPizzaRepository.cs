using PizzaAPI.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaAPI.Context
{
    public interface IPizzaRepository
    {
        Task<Pizza> Get(int id);  // Definição do método Get
        Task<List<Pizza>> GetAll();
        Task AddAsync(Pizza pizza);
        Task UpdateAsync(Pizza pizza);
        Task DeleteAsync(int id);
    }

}
