using GestaoProduto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoProduto.Infrastructure.DI.Extensions
{
    public static class Util
    {
        public static void ConfigurarDb(this IServiceCollection services, IConfiguration configuration)
        {
            string stringConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GestaoProdutoDbContext>(dbContextOption =>
            {
                dbContextOption.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection), b => b.MigrationsAssembly("GestaoProduto.Infrastructure"));
            });
        }
    }
}
