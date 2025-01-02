using DuAnWebAPI.Services.OtpEmail;
using DuAnWebAPI.Services.Res;
using DuAnWebData.Data;
using DuAnWebData.Model;
using Microsoft.EntityFrameworkCore;
using DuAnWebAPI.Services.Res;
using DuAnWebAPI.Services.Buy;
using DuAnWebAPI.Services.Session;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<Iemail, EmailService>();
builder.Services.AddScoped<SessionLogin, SessionService>();
builder.Services.AddScoped<ICartcs, CartService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", corsBuilder =>
    {
        corsBuilder.WithOrigins("https://localhost:7124", "https://localhost:7185", "http://localhost:3000", "http://localhost:3001", "http://localhost:5173")  
                   .AllowAnyHeader()
                   .AllowAnyMethod();
    });
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
