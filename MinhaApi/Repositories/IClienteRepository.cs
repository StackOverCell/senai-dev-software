using MinhaApi.Models;
namespace MinhaApi.Repository;

public interface IClienteRepository
{
    IEnumerable<Cliente> GetAll();
    Cliente? GetById(int id);
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(int id);
}