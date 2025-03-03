using GestionDhotelesIOC.Dependencies;
using GestionDhotelesPercistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GestionDhotelesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion_con_GestionDhotelesDbContext")));
// Add services to the container.
builder.Services.AddClienteDepedency();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
