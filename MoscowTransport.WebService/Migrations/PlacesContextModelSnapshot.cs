﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using placesFestFlowerJam.InfrastructureServices.Gateways.Database;

namespace placesFestFlowerJam.WebService.Migrations
{
    [DbContext(typeof(PlacesContext))]
    partial class PlacesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("MoscowPlacesFestFlowerJam.DomainObjects.Fest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeridoOf")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberTP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkWeekdays")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkWeekend")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Routes");

                    b.HasData(
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
                        });
                });

            modelBuilder.Entity("placesFestFlowerJam.DomainObjects.TransportOrganization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeZone")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FestFJ");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "---",
                            TimeZone = "Europe/Moscow",
                            WebSite = "http://data.mos.ru"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "---",
                            TimeZone = "Europe/Moscow",
                            WebSite = "http://data.mos.ru"
                        });
                });

            modelBuilder.Entity("FestFJ.DomainObjects.Route", b =>
                {
                    b.HasOne("FestFJ.DomainObjects.TransportOrganization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");
                });
#pragma warning restore 612, 618
        }
    }
}