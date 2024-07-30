using Microsoft.OpenApi.Models;
using RabbitMQMongoExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Servisleri ekleyin
builder.Services.AddControllers();
builder.Services.AddSingleton<RabbitMQService>();
builder.Services.AddSingleton<MongoDBService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Swagger/OpenAPI konfigürasyonu
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "RabbitMQMongoExample API", 
        Version = "v1" 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// HTTP isteği hattını yapılandırma
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMQMongoExample API v1");
        c.RoutePrefix = string.Empty;  // Swagger UI ana sayfa olarak kullanılsın
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();