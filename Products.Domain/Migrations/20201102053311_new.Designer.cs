﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products.Domain.AppContext;

namespace Products.Domain.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20201102053311_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Products.Domain.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a5308b51-5900-48d0-a8c3-bd278d58659d"),
                            Email = "admin@yahoo.com",
                            Password = "111111",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("22bd1b08-5b42-4d11-ab16-48520922dc4b"),
                            Email = "user@gmail.com",
                            Password = "222222",
                            Role = "User",
                            Username = "user"
                        },
                        new
                        {
                            Id = new Guid("8382e91b-f11d-4653-a96a-3739618a3f6a"),
                            Email = "stephen@hotmail.com",
                            Password = "333333",
                            Role = "User",
                            Username = "stephen"
                        });
                });

            modelBuilder.Entity("Products.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d36a202c-a440-4632-b967-df1c69308240"),
                            Category = "Phones & Tablets",
                            Description = "Lastest Iphone 11 Pro, Now available for sale",
                            Name = "Iphone 11 Pro",
                            Price = 369000m
                        },
                        new
                        {
                            Id = new Guid("c6a2270d-1e92-48d0-9b23-a82b81c5a249"),
                            Category = "Phones & Tablets",
                            Description = "New Umidigi Smartphone, very affordable",
                            Name = "Umidigi A5 Pro",
                            Price = 49000m
                        },
                        new
                        {
                            Id = new Guid("52b45712-f3b4-4095-abf8-7d50b2dc8f81"),
                            Category = "Phones & Tablets",
                            Description = "Latest tchno andriod phone",
                            Name = "Techo Hot 8 lite",
                            Price = 38000m
                        });
                });

            modelBuilder.Entity("Products.Domain.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Products.Domain.RefreshToken", b =>
                {
                    b.HasOne("Products.Domain.ApplicationUser", "ApplicationUser")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("ApplicationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
