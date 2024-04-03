using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestTask;
using TestTask.Data;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TestTask",
        Description = "Test task for an internship at a company",
        Contact = new OpenApiContact()
        {
            Name = "Vladislav Lashkin",
            Url = new Uri("https://www.linkedin.com/in/vlados1kin/")
        }
    });
});

builder.Services.AddScoped<IOrderService, OrderService>()
    .AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();