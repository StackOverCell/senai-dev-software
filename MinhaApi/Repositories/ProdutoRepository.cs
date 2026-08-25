using MinhaApi.Models;
using MinhaApi.Repository;

public class ProdutoRepository: IProdutoRepository
{
  private static List<Produto> _db = new()
  {
    new Produto { Id=1, Nome="Notebook", Preco=2500m, Estoque=10 },
    new Produto { Id=2, Nome="Mouse", Preco=89.90m, Estoque=50 }
  };

  public IEnumerable<Produto> GetAll()
      => _db;

  public Produto? GetById(int id)
      => _db.FirstOrDefault(p => p.Id == id);

  public void Add(Produto p)
  {
      p.Id = _db.Any() ? _db.Max(x => x.Id) + 1 : 1;
      _db.Add(p);
  }

  public void Update(Produto p)
  {
      var i = _db.FindIndex(x => x.Id == p.Id);
      if (i >= 0) _db[i] = p;
  }

  public void Delete(int id)
      => _db.RemoveAll(p => p.Id == id);
}