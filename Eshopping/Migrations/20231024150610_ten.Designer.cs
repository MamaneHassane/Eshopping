﻿// <auto-generated />
using System;
using Eshopping.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eshopping.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231024150610_ten")]
    partial class ten
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.22");

            modelBuilder.Entity("Eshopping.Models.Cart", b =>
                {
                    b.Property<int>("cartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("clientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("cartId");

                    b.HasIndex("ProductId");

                    b.HasIndex("clientId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Eshopping.Models.Client", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("dateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("clientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Eshopping.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Eshopping.Models.Cart", b =>
                {
                    b.HasOne("Eshopping.Models.Product", null)
                        .WithMany("carts")
                        .HasForeignKey("ProductId");

                    b.HasOne("Eshopping.Models.Client", "client")
                        .WithOne("cart")
                        .HasForeignKey("Eshopping.Models.Cart", "clientId");

                    b.Navigation("client");
                });

            modelBuilder.Entity("Eshopping.Models.Client", b =>
                {
                    b.Navigation("cart");
                });

            modelBuilder.Entity("Eshopping.Models.Product", b =>
                {
                    b.Navigation("carts");
                });
#pragma warning restore 612, 618
        }
    }
}
