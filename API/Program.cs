using System.Reflection;
using System.Text.Json.Serialization;
using API.Extensions;
using AspNetCoreRateLimit;
using iText.Kernel.XMP.Options;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.ConfigCores();
builder.Services.AddAplicationServices();
builder.Services.ConfigureRateLimiting();
builder.Services.ConfigureApiVersioning();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader =true;
}
).AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
.AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    string ? ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(ConnectionString,ServerVersion.AutoDetect(ConnectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseIpRateLimiting();
app.UseApiVersioning(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
