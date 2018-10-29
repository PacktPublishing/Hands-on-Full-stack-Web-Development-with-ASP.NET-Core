﻿// <auto-generated />
using GiveNTake.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GiveNTake.Migrations
{
    [DbContext(typeof(GiveNTakeContext))]
    [Migration("20180219101736_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GiveNTake.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GiveNTake.Model.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("GiveNTake.Model.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("FromUserUserId");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Title");

                    b.Property<string>("ToUserUserId");

                    b.HasKey("MessageId");

                    b.HasIndex("FromUserUserId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ToUserUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("GiveNTake.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<int?>("CityId");

                    b.Property<string>("Description");

                    b.Property<string>("OwnerUserId");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GiveNTake.Model.ProductMedia", b =>
                {
                    b.Property<int>("ProductMediaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProductId");

                    b.Property<string>("Url");

                    b.HasKey("ProductMediaId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMedia");
                });

            modelBuilder.Entity("GiveNTake.Model.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GiveNTake.Model.Category", b =>
                {
                    b.HasOne("GiveNTake.Model.Category", "ParentCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("GiveNTake.Model.Message", b =>
                {
                    b.HasOne("GiveNTake.Model.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserUserId");

                    b.HasOne("GiveNTake.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("GiveNTake.Model.User", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserUserId");
                });

            modelBuilder.Entity("GiveNTake.Model.Product", b =>
                {
                    b.HasOne("GiveNTake.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("GiveNTake.Model.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("GiveNTake.Model.User", "Owner")
                        .WithMany("Products")
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("GiveNTake.Model.ProductMedia", b =>
                {
                    b.HasOne("GiveNTake.Model.Product")
                        .WithMany("Media")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
