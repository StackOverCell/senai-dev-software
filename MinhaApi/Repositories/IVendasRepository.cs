using MinhaApi.Models;

namespace MinhaApi.Repository;

public interface IVendaRepository
{
    IEnumerable<Venda> GetAll();
    Venda? GetById(int id);
    void Add(Venda venda);
}