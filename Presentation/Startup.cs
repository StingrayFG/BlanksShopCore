﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("customers", new OpenApiInfo { Title = "customers", Version = "v1" });
                options.SwaggerDoc("orders", new OpenApiInfo { Title = "orders", Version = "v1" });
                options.SwaggerDoc("shoppingcarts", new OpenApiInfo { Title = "shoppingcarts", Version = "v1" });

                options.SwaggerDoc("parts", new OpenApiInfo { Title = "parts", Version = "v1" });
                options.SwaggerDoc("metalblanks", new OpenApiInfo { Title = "metalblanks", Version = "v1" });
                options.SwaggerDoc("machines", new OpenApiInfo { Title = "machines", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/customers/swagger.json", "customers");
                    options.SwaggerEndpoint("/swagger/orders/swagger.json", "orders");
                    options.SwaggerEndpoint("/swagger/shoppingcarts/swagger.json", "shoppingcarts");

                    options.SwaggerEndpoint("/swagger/parts/swagger.json", "parts");
                    options.SwaggerEndpoint("/swagger/metalblanks/swagger.json", "metalblanks");
                    options.SwaggerEndpoint("/swagger/machines/swagger.json", "machines");
                });
            }

            app.UseCors("CorsPolicy");

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