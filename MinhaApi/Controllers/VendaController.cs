using MinhaApi.Models;
using MinhaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly IVendaService _service;

    public VendaController(IVendaService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult create([FromBody] Venda venda)
    {
        try
        {
            var realizada = _service.create(
                venda.ClienteId,
                venda.ProdutoId,
                venda.Quantidade
            );

            return Ok(realizada);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                erro = ex.Message
            });
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var vendas = _service.GetAll();

        return Ok(vendas);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var venda = _service.GetById(id);

        if (venda == null)
            return NotFound(new
            {
                erro = "Venda não encontrada."
            });

        return Ok(venda);
    }
}