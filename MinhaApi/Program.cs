using MinhaApi.Repository;
using MinhaApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Registra o Reposiory
builder.Services.AddScoped<
    IProdutoRepository,
    ProdutoRepository>();

builder.Services.AddScoped<
    IClienteRepository,
    ClienteRepository>();

// Registra a Service
builder.Services.AddScoped<
    IProdutoService,
    ProdutoService>();
    
builder.Services.AddScoped<
    IClienteService,
    ClienteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();