using cashierAPI.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Membaca connection string dari appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<databaseContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26))));
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
