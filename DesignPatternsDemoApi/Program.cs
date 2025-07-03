using DesignPatternsDemoApi.Data;
using DesignPatternsDemoApi.Interfaces;
using DesignPatternsDemoApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Builder Pattern - step-by-step configuration
builder.Services.AddControllers(); // Front Controller
builder.Services.AddEndpointsApiExplorer(); // Swagger endpoint discovery
builder.Services.AddSwaggerGen(); // Strategy + Builder pattern for Swagger

// 2. Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();

// 3. EF Core (In-Memory DB for demo)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("DemoDb")); // Unit of Work + Repository

// 4. CORS Policy Pattern
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// 5. Chain of Responsibility - middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Dev error page
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting(); // Middleware
app.UseCors("AllowAll"); // Policy Pattern
app.UseAuthorization(); // Interceptor

app.MapControllers(); // Front Controller

app.Run(); // App launch
