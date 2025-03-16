using Calculator;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Register Calculator Services
builder.Services.AddSingleton<SimpleCalculator>();
builder.Services.AddSingleton<CachedCalculator>();

// Add Swagger (Swashbuckle)
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Calculator API",
        Version = "v1"
    });
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5174") 
            .AllowAnyMethod()
            .AllowAnyHeader());
});

/*
// Fetch connection string from environment variable (fallback to appsettings.json)
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") 
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

// Register Database Context (Example using Entity Framework)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    */

var app = builder.Build();

// ✅ Always enable Swagger (no environment check)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculator API v1");
    c.RoutePrefix = string.Empty;
});

// Security & CORS
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();

// Controllers
app.MapControllers();

// Start the application
app.Run();