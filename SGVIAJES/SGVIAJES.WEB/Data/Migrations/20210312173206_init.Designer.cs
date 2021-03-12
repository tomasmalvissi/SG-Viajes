﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGVIAJES.WEB.Data;

namespace SGVIAJES.WEB.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210312173206_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGVIAJES.DATA.Viaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaViaje")
                        .HasColumnType("datetime2");

                    b.Property<float>("GNC")
                        .HasColumnType("real");

                    b.Property<float>("Importe")
                        .HasColumnType("real");

                    b.Property<float>("ImporteEsp")
                        .HasColumnType("real");

                    b.Property<float>("KM")
                        .HasColumnType("real");

                    b.Property<float>("MinEsper")
                        .HasColumnType("real");

                    b.Property<float>("Nafta")
                        .HasColumnType("real");

                    b.Property<int>("NroViaje")
                        .HasColumnType("int");

                    b.Property<string>("Origen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PeajeEst")
                        .HasColumnType("real");

                    b.Property<float>("PrecioEspera")
                        .HasColumnType("real");

                    b.Property<float>("PrecioKM")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Viajes");
                });
#pragma warning restore 612, 618
        }
    }
}