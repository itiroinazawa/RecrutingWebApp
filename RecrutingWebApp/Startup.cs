using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecrutingWebApp.Application.Gateway;
using RecrutingWebApp.Application.Gateway.Interface;
using RecrutingWebApp.Util.Context;
using RecrutingWebApp.Repository;
using RecrutingWebApp.Repository.Interface;

namespace RecrutingWebApp
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
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());

            services.AddTransient<IPessoaGateway, PessoaGateway>();
            services.AddTransient<ICandidaturaGateway, CandidaturaGateway>();
            services.AddTransient<IRankingGateway, RankingGateway>();
            services.AddTransient<IVagaGateway, VagaGateway>();

            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<ICandidaturaRepository, CandidaturaRepository>();
            services.AddTransient<IRankingRepository, RankingRepository>();
            services.AddTransient<IVagaRepository, VagaRepository>();

            services.AddMvc();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
