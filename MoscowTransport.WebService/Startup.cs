using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using placesFestFlowerJam.ApplicationServices.GetFestListUseCase;
using placesFestFlowerJam.ApplicationServices.Repositories;
using placesFestFlowerJam.DomainObjects.Ports;
using placesFestFlowerJam.DomainObjects;
using System.Collections.Generic;

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
            services.AddScoped<InMemoryFestRepository>(x => new InMemoryFestRepository(
                new List<Fest> {
                    new Fest() 
                    { 
                        Id = 1, 
                        Address = "v.31313", 
                        NumberTP = "591", 
                        WorkWeekdays = "10-21",
                        WorkWeekend = "9-19",
                        Organization = x.GetRequiredService<InMemoryFestFJRepository>().GetFestFJ(2).Result
                    },
                    new Fest()
                    {
                        Id = 2,
                        Address = "v.55",
                        NumberTP = "113",
                        WorkWeekdays = "11-21",
                        WorkWeekend = "9-20",
                        Organization = x.GetRequiredService<InMemoryFestFJRepository>().GetFestFJ(2).Result
                    },
                    new Fest()
                    {
                        Id = 3,
                        Address = "v.33",
                        NumberTP = "12",
                        WorkWeekdays = "12-21",
                        WorkWeekend = "11-18",
                        Organization = x.GetRequiredService<InMemoryFestFJRepository>().GetFestFJ(1).Result
                    }
            }));
            services.AddScoped<IReadOnlyFestRepository>(x => x.GetRequiredService<InMemoryFestRepository>());
            services.AddScoped<IFestRepository>(x => x.GetRequiredService<InMemoryFestRepository>());

            services.AddScoped<InMemoryFestFJRepository>(x => new InMemoryFestFJRepository(
                new List<FestFJ> { 
                    new FestFJ() { Id = 1, Name = "Цветочный Джем", TimeZone = "Moscow/Europe", WebSite = "http://data.mos.ru" },
                    new FestFJ() { Id = 2, Name = "Цветочный Джем", TimeZone = "Moscow/Europe", WebSite = "http://data.mos.ru" } 
                }
            ));
            services.AddScoped<IReadOnlyFestFJRepository>(x => x.GetRequiredService<InMemoryFestFJRepository>());
            services.AddScoped<IFestFJRepository>(x => x.GetRequiredService<InMemoryFestFJRepository>());

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
