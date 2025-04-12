
//Uygulama oluþturucu 
var builder = WebApplication.CreateBuilder(args);

//Controller servisini ekler
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

// Configure the HTTP request pipeline.

//Http isteklerini controller'a yönlendirir.
app.MapControllers();
//Uygulamayý çalýþtýrýr
app.Run();

