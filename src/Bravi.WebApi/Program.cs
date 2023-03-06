using Bravi.Application.DI;
using Bravi.Application.Extensions;
using Bravi.Application.Filters;
using Bravi.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers(
//  AQUI SERVE PARA ADICIONAR UM FILTRO DE EXCEÇÃO NAS CONTROLLERS DA API
//    opt =>
//{
//    opt.Filters.Add<HttpResponseExceptionFilter>();
//}
)
    .AddJsonOptions(opt =>
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.ConfigurationDI(configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.UseInlineDefinitionsForEnums();
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //AQUI É O MIDDLEWARE DE RETORNO 500 COM INFORMAÇÕES
    app.UseMiddleware<ExceptionMiddleware>();
}
else
{
    //AQUI É O MIDDLEWARE DE RETORNO 500 SEM INFORMAÇÕES
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();


app.ConfigureMigration();


app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
