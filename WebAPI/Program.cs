using Business;
using Core.Exceptions.Extensions;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoriesServices(builder.Configuration);
builder.Services.AddBusinessServices();


//AddScoped => //Her Http request i�in bir kez olu�turulur
//AddSingleton   => Uygulama ba�lad���nda bir kez olu�turulur. Cache i�lemleri Config ayarlar�n� y�neten servisler
//AddTransiet => Her kullan�mda yeni bir nesne olu�turur.EmailSenderService

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.


TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
        ClockSkew = TimeSpan.Zero
    };
}

);


// Uygulamay� yap�land�r�r
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureCustomExceptionMiddleware();
}

if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.



app.Run();
