using Base;
using BaseService.DataContext;
using BaseService.Services;
using Microsoft.EntityFrameworkCore;
using PassService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

string connectionString = EnvConstants.DbConnection;
var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
builder.Services.AddDbContext<DBContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion,
            builder =>
                builder.MigrationsAssembly(
                    "BaseService"))
        .EnableDetailedErrors());
builder.Services.AddScoped<IPassServices,PassService.Services.PassService>();
builder.Services.AddSingleton<ICryptoService, CryptoService>();
builder.Services.AddSingleton<IPassEncryptService, PassEncryptService>();
builder.Services.AddDataProtection();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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