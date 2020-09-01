using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Task1.Entities;
using Task1.Interfaces;
using Task1.Repositories;

namespace Task1
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
