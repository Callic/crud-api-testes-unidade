using Bravi.Application.Services;
using Bravi.Application.Services.Interfaces;
using Bravi.Domain.Interfaces;
using Bravi.Infra.Context;
using Bravi.Infra.Repositories;
using Bravi.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Bravi.Application.DI
{
    public static class Initializer
    {
        public static void ConfigurationDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BraviDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IPessoaService, PessoaService>();
            //services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
