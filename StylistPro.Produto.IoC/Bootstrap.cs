using StylistPro.Produto.Application.Services;
using StylistPro.Produto.Data.AppData;
using StylistPro.Produto.Data.Repositories;
using StylistPro.Produto.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StylistPro.Produto.Service;

namespace StylistPro.Produto.IoC
{
    public class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(x => {
                x.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });


            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoApplicationService, ProdutoApplicationService>();


        }
    }
}
