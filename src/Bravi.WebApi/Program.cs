using Bravi.Application.DI;
using Bravi.Application.Extensions;
using Bravi.Application.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers(
//  AQUI SERVE PARA ADICIONAR UM FILTRO DE EXCE��O NAS CONTROLLERS DA API
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
    //AQUI � O MIDDLEWARE DE RETORNO 500 COM INFORMA��ES
    app.UseMiddleware<ExceptionMiddleware>();
}
else
{
    //AQUI � O MIDDLEWARE DE RETORNO 500 SEM INFORMA��ES
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
