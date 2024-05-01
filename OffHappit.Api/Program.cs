using Microsoft.Extensions.Configuration;
using OffHappit.Application;
using OffHappit.Persistence;
using static OffHappit.Application.Services.AuthServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AuthServicesOptions>(builder.Configuration.GetSection("AuthServicesOptions"));

builder.Services
    .ConfigureApplicationServices(builder.Configuration)
    .AddPersistenceServices(builder.Configuration);
    
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
