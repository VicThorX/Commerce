using Commerce.API.Mappers;
using Commerce.API.Models;
using Commerce.Data;
using Commerce.Data.Configuration;
using Commerce.Data.Entities;
using Commerce.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Commerce.API
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
            services.Configure<MongoDBConfig>(Configuration.GetSection(nameof(MongoDBConfig)));

            services.AddScoped<ICommerceContext, CommerceContext>();

            // API Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            // API Mappers
            services.AddSingleton<IMapper<UserModel, User>, UserModelToUser>();

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("current", new OpenApiInfo
                {
                    Title = "E-Commerce API",
                    Version = "current",
                    Description = "Commerce API Endopints"
                });
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/current/swagger.json", "Commerce API");
            });
        }
    }
}
