﻿// <auto-generated />
using System;
using AltalizaRentCar.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AltalizaRentCar.API.Migrations
{
    [DbContext(typeof(AltalizaContext))]
    [Migration("20210919192409_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("AltalizaRentCar.API.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("AltalizaRentCar.API.Models.CharacterVehicles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("VehicleId");

                    b.ToTable("CharacterVehicles");
                });

            modelBuilder.Entity("AltalizaRentCar.API.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Imagem")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Price_15Days")
                        .HasColumnType("longtext");

                    b.Property<string>("Price_1Days")
                        .HasColumnType("longtext");

                    b.Property<string>("Price_7Days")
                        .HasColumnType("longtext");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("AltalizaRentCar.API.Models.VehicleCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("VehicleCategory");
                });

            modelBuilder.Entity("AltalizaRentCar.API.Models.CharacterVehicles", b =>
                {
                    b.HasOne("AltalizaRentCar.API.Models.Character", "Character")
                        .WithMany("CharacterVehicles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AltalizaRentCar.API.Models.Vehicle", "Vehicle")
                        .WithMany("CharacterVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("AltalizaRentCar.API.Models.Vehicle", b =>
                {
                    b.HasOne("AltalizaRentCar.API.Models.VehicleCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AltalizaRentCar.API.Models.Character", b =>
                {
                    b.Navigation("CharacterVehicles");
                });

            modelBuilder.Entity("AltalizaRentCar.API.Models.Vehicle", b =>
                {
                    b.Navigation("CharacterVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
