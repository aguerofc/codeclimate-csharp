using BAS.AuditJournal.Infrastructure;
using log4net.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

//Configure Log4net.
XmlConfigurator.Configure(new FileInfo("log4net.config"));

builder.Services.AddResponseCaching();

builder.Services.AddResponseCompression();

builder.Services.Configure<GzipCompressionProviderOptions>
    (opt =>{        
        opt.Level = CompressionLevel.Optimal;        
    });

//Injecting services.
builder.Services.RegisterServices();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    var cacheProfiles = builder.Configuration
            .GetSection("CacheProfiles")
            .GetChildren();
    foreach (var cacheProfile in cacheProfiles)
    {
        options.CacheProfiles
        .Add(cacheProfile.Key,
        cacheProfile.Get<CacheProfile>());
    }
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>{
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme{
        Description = "api key.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "basic"
        });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                },
                In = ParameterLocation.Header
            },
            new List<string>()        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseResponseCompression();

app.UseResponseCaching();

app.Run();
