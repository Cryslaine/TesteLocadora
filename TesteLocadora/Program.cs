using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using TesteLocadora.Model.Lista;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
////app.MapMethods(ListaCadastrolocacao.Template,)
//app.MapGet("/", () => "Teste API");
//app.MapGet("/locadora/{code}", ([FromQuery]ListaCadastrolocacao locacao) =>
//   {
//       return locacao
//   }
//  );

app.Run();
