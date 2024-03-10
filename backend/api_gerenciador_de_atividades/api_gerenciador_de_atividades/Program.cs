using api_gerenciador_de_atividades.Data;
using api_gerenciador_de_atividades.Data.Dao;
using api_gerenciador_de_atividades.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a configuração para o Kestrel ouvir em todos os endereços
builder.WebHost.UseUrls("http://*:5000", "https://*:5001");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Conexão com o banco de dados
string stringDeConexao = builder.Configuration.GetConnectionString("AtividadeConexao");

// Adiciona o serviço de banco de dados
builder.Services.AddDbContext<AtividadeContext>(configuracoes => configuracoes.UseNpgsql(stringDeConexao));

// Adiciona das configurações do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DisableCORS", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});


// Registra o DAO
builder.Services.AddScoped<AtividadeDao>();

// Registra o Service
builder.Services.AddScoped<AtividadeService>();

// Adiciona o serviço de mapeamento de objetos
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors("DisableCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
