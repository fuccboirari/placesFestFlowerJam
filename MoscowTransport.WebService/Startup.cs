using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using placesFestFlowerJam.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using placesFestFlowerJam.ApplicationServices.Ports.Gateways.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using placesFestFlowerJam.ApplicationServices.GetFestListUseCase;
using placesFestFlowerJam.ApplicationServices.Repositories;
using placesFestFlowerJam.DomainObjects.Ports;


namespace placesFestFlowerJam.WebService
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
            services.AddDbContext<PlacesContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "placesFestFlowerJam.db")}")
            );

            services.AddScoped<IPlacesDatabaseGateway, PlacesEFSqliteGateway>();

            services.AddScoped<DbFestRepository>();
            services.AddScoped<IReadOnlyFestRepository>(x => x.GetRequiredService<DbFestRepository>());
            services.AddScoped<IFestRepository>(x => x.GetRequiredService<DbFestRepository>());

            services.AddScoped<DbFestFJRepository>();
            services.AddScoped<IReadOnlyFestFJRepository>(x => x.GetRequiredService<DbFestFJRepository>());
            services.AddScoped<IFestFJRepository>(x => x.GetRequiredService<DbFestFJRepository>());
             
            services.AddScoped<IGetFestListUseCase, GetFestListUseCase>();
                        
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
