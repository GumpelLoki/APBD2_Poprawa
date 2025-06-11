using Kolos2Poprawa.Data;
using Kolos2Poprawa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddScoped<IDbService, DbService>();
/*
builder.Services.AddScoped<IWashingMachineService, WashingMachineService>();
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();