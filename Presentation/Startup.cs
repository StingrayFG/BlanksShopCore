using Microsoft.AspNetCore.Builder;
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
using Application.Interfaces;
using Application.Services;
using Presentation.Controllers;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Domain.Entities;
using Application.EntitiesUI;

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
            services.AddTransient<ICustomerAppService, CustomerAppService>();
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();
            services.AddTransient<IMaterialAppService, MaterialAppService>();
            services.AddTransient<IRepository<Material>, Repository<Material>>();
            services.AddTransient<IRepository<ProductType>, Repository<ProductType>>();

            services.AddTransient<IMetalBlankAppService<MetalBlank>, MetalBlankAppService>();
            services.AddTransient<IMetalBlankRepository<MetalBlank>, MetalBlankRepository>();
            services.AddTransient<IShoppingCartAppService<ShoppingCart>, ShoppingCartAppService>();
            services.AddTransient<IShoppingCartRepository<ShoppingCart>, ShoppingCartRepository>();
            services.AddTransient<IOrderAppService<Order>, OrderAppService>();
            services.AddTransient<IOrderRepository<Order>, OrderRepository>();

            services.AddTransient<ICatalogAppService<ProductCard>, CatalogAppService>();


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
                options.SwaggerDoc("customer", new OpenApiInfo { Title = "customer", Version = "v1" });
                options.SwaggerDoc("order", new OpenApiInfo { Title = "order", Version = "v1" });
                options.SwaggerDoc("shoppingcart", new OpenApiInfo { Title = "shoppingcart", Version = "v1" });
                options.SwaggerDoc("metalblank", new OpenApiInfo { Title = "metalblank", Version = "v1" });
                options.SwaggerDoc("material", new OpenApiInfo { Title = "material", Version = "v1" });
                options.SwaggerDoc("catalog", new OpenApiInfo { Title = "catalog", Version = "v1" });
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
                    options.SwaggerEndpoint("/swagger/customer/swagger.json", "customer");
                    options.SwaggerEndpoint("/swagger/metalblank/swagger.json", "metalblank");
                    options.SwaggerEndpoint("/swagger/material/swagger.json", "material");
                    options.SwaggerEndpoint("/swagger/order/swagger.json", "order");
                    options.SwaggerEndpoint("/swagger/shoppingcart/swagger.json", "shoppingcart");
                    options.SwaggerEndpoint("/swagger/catalog/swagger.json", "catalog");
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
