using System.Reflection;
using APIFARMACIA.Extensions;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureCors();

builder.Services.ConfigureRateLimiting();
// builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();

var app = builder.Build();

builder.Services.AddDbContext<FarmacyContext>(OptionsBuilder => {
    string connectionString = builder.Configuration.GetConnectionString("MySQLConection");
    OptionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

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
