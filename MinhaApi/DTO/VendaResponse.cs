public class VendaResponse
{
    public int Id { get; set; }

    public DateTime DataVenda { get; set; }

    public decimal ValorUnitario { get; set; }

    public decimal ValorTotal { get; set; }

    public string NomeCliente { get; set; }

    public string NomeProduto { get; set; }
}