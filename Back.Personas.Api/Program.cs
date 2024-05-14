using Microsoft.Extensions.Configuration;
using Back.Personas.Persistencia;
using Back.Personas.Dominio.Interfaces.Commons;
using Back.Personas.Api.Services;
using Back.Personas.CasosDeUso;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUserAuthenticate, UserAuthenticate>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(o => o.AddPolicy("AllowWebapp", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddJwt(config);

builder.Services.Persistencia(config);
builder.Services.Aplicacion();
builder.Services.AddSwagger();

var app = builder.Build();
app.UseCors("AllowWebapp");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
