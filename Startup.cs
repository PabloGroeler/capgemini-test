using capgemini_test.src.Core.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using capgemini_test.src.Core.CrossCutting.DependencyInjection;
using capgemini_test.src.Core.CrossCutting.Mappings;
using AutoMapper;
using Newtonsoft.Json;

namespace capgemini_test
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

            ConfigureDependencyRepositories.ConfigureRepositories(services);
            ConfigureDependencyServices.ConfigureServices(services);

            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DataContext")));
            services.AddControllers();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DtoToModelProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "capgemini_test", Version = "v1" });
            });

            services.AddMvc().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "capgemini_test v1"));
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
