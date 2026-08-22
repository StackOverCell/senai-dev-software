using MinhaApi.Models;
using MinhaApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiContoller]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service => _service = service);

    [HttpGet]
    public IActionResult GetAll()
    {
        var = produtos = _service.GetAll();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _service.GetById(id);
        if(produto == null)
            return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public IActionResult Create(
    [FromBody] Produto produto)
    {
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    var criado = _service.Create(produto);

    return CreatedAtAction(
        nameof(GetById),
        new { id = criado.Id },
        criado);
    }

    {
        "nome": "Notebook",
        "preco": 2500.00,
        "estoque": 10
    }

    // PUT /api/produto/1
    [HttpPut("{id}")]
    public IActionResult Update(
    int id,
    [FromBody] Produto produto)
    {
    var atualizado =
        _service.Update(id, produto);

    if (atualizado == null)
        return NotFound();

    return Ok(atualizado);
    }

    // DELETE /api/produto/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
    var deletado = _service.Delete(id);

    if (!deletado)
        return NotFound();

    return NoContent();
    }
}