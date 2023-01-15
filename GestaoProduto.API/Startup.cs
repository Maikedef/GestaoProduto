using FluentValidation;
using FluentValidation.AspNetCore;
using GestaoProduto.API.Filtro;
using GestaoProduto.Application.Interfaces.Produtos;
using GestaoProduto.Application.Mapper.Produtos;
using GestaoProduto.Application.UseCase.Produtos;
using GestaoProduto.Application.Validations.Produtos;
using GestaoProduto.Domain.Repository.Produtos;
using GestaoProduto.Infrastructure.Data.Repository.Produtos;
using GestaoProduto.Infrastructure.DI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GestaoProduto.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigurarDb(Configuration);
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddAutoMapper(typeof(ProdutoMapper));
            services.AddScoped<IApplicationUseCaseProduto, ApplicationUseCaseProduto>();

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<InserirProdutoValidation>();

            services.AddMvc(option => option.Filters.Add(typeof(FiltroException)));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestaoProduto.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestaoProduto.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
