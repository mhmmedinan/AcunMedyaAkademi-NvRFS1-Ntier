using Business;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoriesServices(builder.Configuration);
builder.Services.AddBusinessServices();


//AddScoped => //Her Http request için bir kez oluþturulur
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
