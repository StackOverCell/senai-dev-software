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

// Registra a Service
builder.Services.AddScoped<
    IProdutoService,
    ProdutoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();