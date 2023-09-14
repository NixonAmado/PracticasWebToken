using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistencia.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureCors();//--
builder.Services.AddAplicacionServices();//--
builder.Services.AddJwt(builder.Configuration);//--
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PracticasTokenContext>(options =>
    {
        string connectionString = builder.Configuration.GetConnectionString("conexMySql");
        options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
    }

);

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");//--
app.UseHttpsRedirection();
app.UseAuthentication();//--
app.UseAuthorization();
app.MapControllers();
app.Run();