using MinhaApi.Models;

namespace MinhaApi.Services;

public interface IVendaService
{
    Venda RealizarVenda(int clienteId, int produtoId, int quantidade);

    IEnumerable<Venda> GetAll();

    Venda? GetById(int id);
}
