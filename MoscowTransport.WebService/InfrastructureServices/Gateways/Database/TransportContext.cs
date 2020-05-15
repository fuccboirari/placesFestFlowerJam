using Microsoft.EntityFrameworkCore;
using placesFestFlowerJam.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace placesFestFlowerJam.InfrastructureServices.Gateways.Database
{
    public class PlacesContext : DbContext
    {
        public DbSet<Fest> Routes { get; set; }

        public DbSet<FestFJ> TransportOrganizations { get; set; }

        public PlacesContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {
            var to1 = new FestFJ {
                Id = 1L,
                Name = "---",
                TimeZone = "Europe/Moscow",
                WebSite = "http://data.mos.ru"
            };

            var to2 = new FestFJ {
                Id = 2L,
                Name = "---",
                TimeZone = "Europe/Moscow",
                WebSite = "http://data.mos.ru"
            };

            modelBuilder.Entity<FestFJ>().HasData(
               to1,
               to2
            );

            modelBuilder.Entity<Fest>().HasData(
                new
                {
                    Id = 1L,
                    Address = "Gorkogo 14",
                    PeriodOf = "10.10.2019-22.10.2019",
                    NumberTP = "591",
                    WorkWeekdays = "10-21",
                    WorkWeekend = "9-22",
                    OrganizationId = 1L,
                },
                new
                {
                    Id = 2L,
                    Address = "ABc 14",
                    PeriodOf = "11.02.2019-23.04.2019",
                    NumberTP = "145",
                    WorkWeekdays = "10-21",
                    WorkWeekend = "9-22",
                    OrganizationId = 1L,
                },
                new
                {
                    Id = 3L,
                    Address = "Lenina 1",
                    PeriodOf = "10.11.2019-22.12.2019",
                    NumberTP = "91",
                    WorkWeekdays = "11-21",
                    WorkWeekend = "9-22",
                    OrganizationId = 1L,
                },
                new
                {
                    Id = 4L,
                    Address = "Gonsalesa 19",
                    PeriodOf = "01.10.2019-02.10.2019",
                    NumberTP = "11",
                    WorkWeekdays = "10-21",
                    WorkWeekend = "9-22",
                    OrganizationId = 1L,
                }
            );
        }
    }
}
