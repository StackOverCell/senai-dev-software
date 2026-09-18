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

    public VendaResponse create(VendaRequest vendaRequest)
    {
        if (vendaRequest.Quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        var cliente = _clienteRepository.GetById(vendaRequest.ClienteId);

        if (cliente == null || !cliente.Ativo)
            throw new ArgumentException("Cliente inexistente ou inativo.");

        var produto = _produtoRepository.GetById(vendaRequest.ProdutoId);

        if (produto == null || !produto.Ativo)
            throw new ArgumentException("Produto inexistente ou inativo.");

        if (produto.Estoque < vendaRequest.Quantidade)
            throw new ArgumentException("Estoque insuficiente.");

        var venda = new Venda
        {
            ClienteId = vendaRequest.ClienteId,
            ProdutoId = vendaRequest.ProdutoId,
            Quantidade = vendaRequest.Quantidade,
            DataVenda = DateTime.Now,
            ValorTotal = produto.Preco * vendaRequest.Quantidade
        };

        _produtoRepository.DiminuirEstoque(produto.Id, vendaRequest.Quantidade);
        _vendaRepository.Add(venda);

        Venda retorno = _vendaRepository.GetById(venda.Id);

        return new VendaResponse
        {
            Id = retorno.Id,
            DataVenda = retorno.DataVenda,
            ValorUnitario = retorno.ValorUnitario,
            ValorTotal = retorno.ValorTotal,
            NomeCliente = cliente.Nome,
            NomeProduto = produto.Nome
        };
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