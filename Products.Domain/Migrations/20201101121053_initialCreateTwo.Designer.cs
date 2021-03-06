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
    [Migration("20201101121053_initialCreateTwo")]
    partial class initialCreateTwo
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
                            Id = new Guid("5547e98e-dac7-49af-a82e-112b1941beb1"),
                            Email = "admin@yahoo.com",
                            Password = "111111",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("90553351-867b-4a10-9301-48eb3a7d3db3"),
                            Email = "user@gmail.com",
                            Password = "222222",
                            Role = "User",
                            Username = "user"
                        },
                        new
                        {
                            Id = new Guid("eb1a5f70-8bc7-409b-a641-ab1f383014aa"),
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
                            Id = new Guid("cb64b796-f71b-4d9c-a604-6006ed867ad7"),
                            Category = "Phones & Tablets",
                            Description = "Lastest Iphone 11 Pro, Now available for sale",
                            Name = "Iphone 11 Pro",
                            Price = 369000m
                        },
                        new
                        {
                            Id = new Guid("750141e9-e0a7-4e0a-8334-6f11823edb04"),
                            Category = "Phones & Tablets",
                            Description = "New Umidigi Smartphone, very affordable",
                            Name = "Umidigi A5 Pro",
                            Price = 49000m
                        },
                        new
                        {
                            Id = new Guid("3f1c7809-8b71-43d9-95ca-7edfcb0b6067"),
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

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expiry")
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
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
