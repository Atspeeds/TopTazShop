﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopTaz.Persistence.TTDbContext;

namespace Persistence.Migrations
{
    [DbContext(typeof(TopTazDbContext))]
    [Migration("20240217202644_InitialBasket")]
    partial class InitialBasket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TopTaz.Domain.BasketAgg.Basket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("TopTaz.Domain.BasketAgg.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<long?>("BasketId1")
                        .HasColumnType("bigint");

                    b.Property<int>("CatalogItemId")
                        .HasColumnType("int");

                    b.Property<long?>("CatalogItemId1")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasketId1");

                    b.HasIndex("CatalogItemId1");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogBrand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CatalogBrands");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Brand = "سامسونگ"
                        },
                        new
                        {
                            Id = 2L,
                            Brand = "شیائومی "
                        },
                        new
                        {
                            Id = 3L,
                            Brand = "اپل"
                        },
                        new
                        {
                            Id = 4L,
                            Brand = "هوآوی"
                        },
                        new
                        {
                            Id = 5L,
                            Brand = "نوکیا "
                        },
                        new
                        {
                            Id = 6L,
                            Brand = "ال جی"
                        });
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("AvailableStock")
                        .HasColumnType("int");

                    b.Property<long>("CatalogBrandId")
                        .HasColumnType("bigint");

                    b.Property<long>("CatalogTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RestockThreshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogBrandId");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("CatalogItems");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogItemFeature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CatalogItemId")
                        .HasColumnType("bigint");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CatalogItemId");

                    b.ToTable("CatalogItemFeature");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogItemImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CatalogItemId")
                        .HasColumnType("bigint");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CatalogItemId");

                    b.ToTable("CatalogItemImage");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("ParentCatalogTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCatalogTypeId");

                    b.ToTable("CatalogTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Type = "کالای دیجیتال"
                        },
                        new
                        {
                            Id = 2L,
                            ParentCatalogTypeId = 1L,
                            Type = "لوازم جانبی گوشی"
                        },
                        new
                        {
                            Id = 3L,
                            ParentCatalogTypeId = 2L,
                            Type = "پایه نگهدارنده گوشی"
                        },
                        new
                        {
                            Id = 4L,
                            ParentCatalogTypeId = 2L,
                            Type = "پاور بانک (شارژر همراه)"
                        },
                        new
                        {
                            Id = 5L,
                            ParentCatalogTypeId = 2L,
                            Type = "کیف و کاور گوشی"
                        });
                });

            modelBuilder.Entity("TopTaz.Domain.BasketAgg.BasketItem", b =>
                {
                    b.HasOne("TopTaz.Domain.BasketAgg.Basket", null)
                        .WithMany("Items")
                        .HasForeignKey("BasketId1");

                    b.HasOne("TopTaz.Domain.CatalogAgg.CatalogItem", "CatalogItem")
                        .WithMany()
                        .HasForeignKey("CatalogItemId1");

                    b.Navigation("CatalogItem");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogItem", b =>
                {
                    b.HasOne("TopTaz.Domain.CatalogAgg.CatalogBrand", "CatalogBrand")
                        .WithMany()
                        .HasForeignKey("CatalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopTaz.Domain.CatalogAgg.CatalogType", "CatalogType")
                        .WithMany()
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogBrand");

                    b.Navigation("CatalogType");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogItemFeature", b =>
                {
                    b.HasOne("TopTaz.Domain.CatalogAgg.CatalogItem", "CatalogItem")
                        .WithMany("catalogItemFeatures")
                        .HasForeignKey("CatalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogItem");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogItemImage", b =>
                {
                    b.HasOne("TopTaz.Domain.CatalogAgg.CatalogItem", "CatalogItem")
                        .WithMany("CatalogItemImages")
                        .HasForeignKey("CatalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogItem");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogType", b =>
                {
                    b.HasOne("TopTaz.Domain.CatalogAgg.CatalogType", "ParentCatalogType")
                        .WithMany("ChildCatalogType")
                        .HasForeignKey("ParentCatalogTypeId");

                    b.Navigation("ParentCatalogType");
                });

            modelBuilder.Entity("TopTaz.Domain.BasketAgg.Basket", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogItem", b =>
                {
                    b.Navigation("catalogItemFeatures");

                    b.Navigation("CatalogItemImages");
                });

            modelBuilder.Entity("TopTaz.Domain.CatalogAgg.CatalogType", b =>
                {
                    b.Navigation("ChildCatalogType");
                });
#pragma warning restore 612, 618
        }
    }
}