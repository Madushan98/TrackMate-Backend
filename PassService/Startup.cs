﻿using Base;
using BaseService.Contract.Mappers;
using BaseService.DataContext;
using BaseService.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore;
using PassService.Services;

namespace PassService;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });

        // services.AddDbContext<AuthContext>(options =>
        // {
        //     options.UseMySql(Configuration.GetConnectionString("WorkflowDB"));
        // });

        // Replace with your server version and type.
        // Use 'MariaDbServerVersion' for MariaDB.
        // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
        // For common usages, see pull request #1233.
        // Replace 'YourDbContext' with the name of your own DbContext derived class.
        DataBaseDependency.Initialize(services);

        
        services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
        services.AddScoped<IPassServices,Services.PassService>();
        services.AddScoped<IPassLogService,PassLogService>();
        services.AddSingleton<IPassEncryptService, PassEncryptService>();
        services.AddDataProtection().UseCryptographicAlgorithms(
            new AuthenticatedEncryptorConfiguration
            {
                EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
            }
        );;
        services.AddAutoMapper(typeof(Startup),typeof(CommonMapper));
        services.AddSingleton<ICryptoService, CryptoService>();
        services.AddSingleton<ICryptoService, CryptoService>();
        services.AddSingleton<ITokenService, TokenService>();
        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API V1");
            c.RoutePrefix = string.Empty;
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("CorsPolicy");
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}