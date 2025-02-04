using Microsoft.EntityFrameworkCore;
using PizzaAPI.Context; // Certifique-se de usar o namespace correto
using PizzaAPI.Modelos; // Certifique-se de importar o namespace correto.
                        // ou o namespace correto que contém o seu PizzariaContext

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using PizzariaAPI;

var builder = WebApplication.CreateBuilder(args);

// 🔹 REGISTRAR O CONTEXTO DO BANCO DE DADOS
string connectionString = "Server=PCLUCAS\\SQLEXPRESS;Database=PizzariaDB;User Id=pizzaria_user;Password=NovaSenhaSegura123!;TrustServerCertificate=True;";

builder.Services.AddDbContext<PizzariaContext>(options =>
    options.UseSqlServer(connectionString)
);

// 🔹 ADICIONANDO SERVIÇOS MVC
builder.Services.AddControllers();  // ESSENCIAL PARA OS CONTROLLERS FUNCIONAREM

// 🔹 CONFIGURAÇÃO DA AUTENTICAÇÃO JWT
var key = Encoding.UTF8.GetBytes(ChaveSecreta.chaveSecreta);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

// 🔹 CONFIGURAÇÃO DO SWAGGER
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaAPI", Version = "v1" });

    options.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira apenas o Token JWT no campo abaixo."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "JWT"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// 🔹 ATIVANDO SWAGGER NO AMBIENTE DE DESENVOLVIMENTO
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 PIPELINE DA APLICAÇÃO
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
