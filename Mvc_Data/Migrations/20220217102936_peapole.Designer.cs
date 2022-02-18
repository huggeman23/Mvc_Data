﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mvc_Data;

namespace Mvc_Data.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20220217102936_peapole")]
    partial class peapole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mvc_Data.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CounteryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.HasIndex("CounteryName");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            CounteryName = "USA",
                            Name = "Montana"
                        });
                });

            modelBuilder.Entity("Mvc_Data.Models.Countery", b =>
                {
                    b.Property<string>("CounteryName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CounteryName");

                    b.ToTable("Countery");

                    b.HasData(
                        new
                        {
                            CounteryName = "USA"
                        });
                });

            modelBuilder.Entity("Mvc_Data.Models.CreatePersonViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityID");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityID = 1,
                            Name = "Mathiew",
                            Phone = 220002298
                        });
                });

            modelBuilder.Entity("Mvc_Data.Models.City", b =>
                {
                    b.HasOne("Mvc_Data.Models.Countery", "Countery")
                        .WithMany("cityList")
                        .HasForeignKey("CounteryName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mvc_Data.Models.CreatePersonViewModel", b =>
                {
                    b.HasOne("Mvc_Data.Models.City", "City")
                        .WithMany("peapoleList")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
