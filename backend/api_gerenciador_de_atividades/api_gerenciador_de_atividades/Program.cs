using api_gerenciador_de_atividades.Data;
using api_gerenciador_de_atividades.Data.Dao;
using api_gerenciador_de_atividades.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a configura��o para o Kestrel ouvir em todos os endere�os
builder.WebHost.UseUrls("http://*:5000", "https://*:5001");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Conex�o com o banco de dados
string stringDeConexao = builder.Configuration.GetConnectionString("AtividadeConexao");

// Adiciona o servi�o de banco de dados
builder.Services.AddDbContext<AtividadeContext>(configuracoes => configuracoes.UseNpgsql(stringDeConexao));

// Adiciona das configura��es do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173") // Substitua pelo(s) dom�nio(s) correto(s) se necess�rio
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});

// Registra o DAO
builder.Services.AddScoped<AtividadeDao>();

// Registra o Service
builder.Services.AddScoped<AtividadeService>();

// Adiciona o servi�o de mapeamento de objetos
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// UseCors deve ser chamado com o nome da pol�tica que voc� definiu. Eu ajustei para usar "AllowSpecificOrigin" conforme definido acima
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
