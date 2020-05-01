using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TourOfHeroes.Api.Interfaces;
using TourOfHeroes.Api.Models;
using TourOfHeroes.Api.Services;

namespace TourOfHeroes.Api
{
    public class Startup
    {
        private const string CorsPolicyName = "CustomCorsPolicyName";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<HeroesDatabaseSettings>(
                Configuration.GetSection(nameof(HeroesDatabaseSettings)));

            services.AddSingleton<IHeroesDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<HeroesDatabaseSettings>>().Value);

            services.AddSingleton<HeroService>();

            services.AddCors(options => 
            {
                options.AddPolicy(name: CorsPolicyName, builder => 
                {
                    builder.WithOrigins("http://localhost:4200") //Angular
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(CorsPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
