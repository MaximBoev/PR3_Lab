using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PR3_Lab.Persistence;

var builder = WebApplication.CreateBuilder(args);

// ��������� CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", builder =>
    {
        builder.WithOrigins("https://localhost:5058")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// ����������� ������������
builder.Services.AddControllers();

// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "To Do API",
        Version = "v1"
    });
});

// ��������� ����������� � ���� ������
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// �������������� ��������/���������� ���� ������
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // ������ ������� �� ������ �������
    // db.Database.Migrate(); // ����������������, ���� ����� ��������
}

// ������������ ��������� HTTP-��������
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