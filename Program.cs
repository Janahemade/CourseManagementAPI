using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ================== SERVICES ==================

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// Your Service
builder.Services.AddScoped<StudentService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ================== JWT AUTH ==================

var key = "THIS_IS_A_VERY_LONG_SECRET_KEY_1234567890";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

builder.Services.AddAuthorization();

// ================== BUILD ==================

var app = builder.Build();

// ================== MIDDLEWARE ==================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔐 IMPORTANT: Authentication & Authorization
app.UseAuthentication();   // 👈 FIRST
app.UseAuthorization();    // 👈 SECOND

// Map controllers
app.MapControllers();

// Test endpoint (optional)
app.MapGet("/", () => "API is running...");

app.Run();