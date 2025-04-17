using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PR3_Lab.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", builder =>
    {
        builder.WithOrigins("https://localhost:5058")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Регистрация контроллеров
builder.Services.AddControllers();

// Настройка Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "To Do API",
        Version = "v1"
    });
});

// Настройка подключения к базе данных
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Автоматическое создание/обновление базы данных
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // Создаёт таблицы на основе моделей
    // db.Database.Migrate(); // Раскомментируйте, если нужны миграции
}

// Конфигурация пайплайна HTTP-запросов
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "To Do API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseCors("AllowBlazorClient");
app.UseAuthorization();
app.MapControllers();

app.Run();