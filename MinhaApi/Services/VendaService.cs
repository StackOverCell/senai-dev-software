using MinhaApi.Models;
using MinhaApi.Repository;

namespace MinhaApi.Services;

public class VendaService : IVendaService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IVendaRepository _vendaRepository;

    public VendaService(
        IClienteRepository clienteRepository,
        IProdutoRepository produtoRepository,
        IVendaRepository vendaRepository)
    {
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
        _vendaRepository = vendaRepository;
    }

    public Venda RealizarVenda(int clienteId, int produtoId, int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        var cliente = _clienteRepository.GetById(clienteId);

        if (cliente == null || !cliente.Ativo)
            throw new ArgumentException("Cliente inexistente ou inativo.");

        var produto = _produtoRepository.GetById(produtoId);

        if (produto == null || !produto.Ativo)
            throw new ArgumentException("Produto inexistente ou inativo.");

        if (produto.Estoque < quantidade)
            throw new ArgumentException("Estoque insuficiente.");

        var venda = new Venda
        {
            ClienteId = cliente.Id,
            ProdutoId = produto.Id,
            DataVenda = DateTime.Now,
            Quantidade = quantidade,
            ValorUnitario = produto.Preco,
            ValorTotal = produto.Preco * quantidade
        };

        _produtoRepository.DiminuirEstoque(produto.Id, quantidade);
        _vendaRepository.Add(venda);

        return venda;
    }

    public IEnumerable<Venda> GetAll()
    {
        return _vendaRepository.GetAll();
    }

    public Venda? GetById(int id)
    {
        return _vendaRepository.GetById(id);
    }
}
