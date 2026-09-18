using MinhaApi.Models;
namespace MinhaApi.Services;

public interface IVendaService
{
    VendaResponse create(VendaRequest vendaRequest);
    IEnumerable<Venda> GetAll();
    Venda? GetById(int id);
}