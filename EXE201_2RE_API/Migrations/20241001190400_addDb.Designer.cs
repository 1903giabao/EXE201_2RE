﻿// <auto-generated />
using System;
using EXE201_2RE_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EXE201_2RE_API.Migrations
{
    [DbContext(typeof(EXE201Context))]
    [Migration("20241001190400_addDb")]
    partial class addDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EXE201_2RE_API.Models.TblCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("tblCarts");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblCartDetail", b =>
                {
                    b.Property<int>("CartDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartDetailId"), 1L, 1);

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CartDetailId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("tblCartDetails");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("tblCategories");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblFavorite", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavoriteId"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FavoriteId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("tblFavorites");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblGenderCategory", b =>
                {
                    b.Property<int>("GenderCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderCategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderCategoryId");

                    b.ToTable("tblGenderCategories");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblOrderHistory", b =>
                {
                    b.Property<int>("OrderHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderHistoryId"), 1L, 1);

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ChangedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderHistoryId");

                    b.HasIndex("CartId");

                    b.ToTable("tblOrderHistories");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ShopOwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GenderCategoryId");

                    b.HasIndex("ShopOwnerId");

                    b.HasIndex("SizeId");

                    b.ToTable("tblProducts");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("tblReviews");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("tblRoles");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblSize", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeId"), 1L, 1);

                    b.Property<string>("SizeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SizeId");

                    b.ToTable("tblSizes");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsShopOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("ShopAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("tblUsers");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblCart", b =>
                {
                    b.HasOne("EXE201_2RE_API.Models.TblUser", "User")
                        .WithMany("TblCarts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblCartDetail", b =>
                {
                    b.HasOne("EXE201_2RE_API.Models.TblCart", "Cart")
                        .WithMany("TblCartDetails")
                        .HasForeignKey("CartId");

                    b.HasOne("EXE201_2RE_API.Models.TblProduct", "Product")
                        .WithMany("TblCartDetails")
                        .HasForeignKey("ProductId");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblFavorite", b =>
                {
                    b.HasOne("EXE201_2RE_API.Models.TblProduct", "Product")
                        .WithMany("TblFavorites")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EXE201_2RE_API.Models.TblUser", "User")
                        .WithMany("TblFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblOrderHistory", b =>
                {
                    b.HasOne("EXE201_2RE_API.Models.TblCart", "Cart")
                        .WithMany("TblOrderHistories")
                        .HasForeignKey("CartId");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblProduct", b =>
                {
                    b.HasOne("EXE201_2RE_API.Models.TblCategory", "Category")
                        .WithMany("TblProducts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EXE201_2RE_API.Models.TblGenderCategory", "GenderCategory")
                        .WithMany("TblProducts")
                        .HasForeignKey("GenderCategoryId");

                    b.HasOne("EXE201_2RE_API.Models.TblUser", "ShopOwner")
                        .WithMany("TblProducts")
                        .HasForeignKey("ShopOwnerId");

                    b.HasOne("EXE201_2RE_API.Models.TblSize", "Size")
                        .WithMany("TblProducts")
                        .HasForeignKey("SizeId");

                    b.Navigation("Category");

                    b.Navigation("GenderCategory");

                    b.Navigation("ShopOwner");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblReview", b =>
                {
                    b.HasOne("EXE201_2RE_API.Models.TblProduct", "Product")
                        .WithMany("TblReviews")
                        .HasForeignKey("ProductId");

                    b.HasOne("EXE201_2RE_API.Models.TblUser", "User")
                        .WithMany("TblReviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblUser", b =>
                {
                    b.HasOne("EXE201_2RE_API.Models.TblRole", "Role")
                        .WithMany("TblUsers")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblCart", b =>
                {
                    b.Navigation("TblCartDetails");

                    b.Navigation("TblOrderHistories");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblCategory", b =>
                {
                    b.Navigation("TblProducts");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblGenderCategory", b =>
                {
                    b.Navigation("TblProducts");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblProduct", b =>
                {
                    b.Navigation("TblCartDetails");

                    b.Navigation("TblFavorites");

                    b.Navigation("TblReviews");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblRole", b =>
                {
                    b.Navigation("TblUsers");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblSize", b =>
                {
                    b.Navigation("TblProducts");
                });

            modelBuilder.Entity("EXE201_2RE_API.Models.TblUser", b =>
                {
                    b.Navigation("TblCarts");

                    b.Navigation("TblFavorites");

                    b.Navigation("TblProducts");

                    b.Navigation("TblReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
