using Business.Abstracts;
using Business.Concretes;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Concretes;
using Repositories.Concretes.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BaseDbContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("BaseDb")));

builder.Services.AddScoped<IBrandService, BrandManager>();      //Her Http request için bir kez oluþturulur
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

//AddSingleton   => Uygulama baþladýðýnda bir kez oluþturulur. Cache iþlemleri Config ayarlarýný yöneten servisler
//AddTransiet => Her kullanýmda yeni bir nesne oluþturur.EmailSenderService

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.


// Uygulamayý yapýlandýrýr
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// Configure the HTTP request pipeline.



app.Run();
