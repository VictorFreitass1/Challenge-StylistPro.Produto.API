using StylistPro.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StylistPro.Produto.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<ProdutoEntity> Produto { get; set; }
    }

}