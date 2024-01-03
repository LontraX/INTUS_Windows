using INTUS_Backend.Repositories;
using INTUS_Backend.Repositories.Interfaces;
using INTUS_Backend.Services.Interfaces;
using INTUS_Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register services
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IWindowService, WindowService>();
builder.Services.AddTransient<ISubElementService, SubElementService>();

// Register repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<APPDBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddCors();



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
// Configure the HTTP request pipeline.
app.UseCors(options =>
{
    options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
});

app.Run();
