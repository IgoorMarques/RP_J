using Dominio.Interfaces.Genericos;
using Entidades.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<AplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();


// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(InterfaceGenerica<>), typeof(RepositorioGenerico<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
