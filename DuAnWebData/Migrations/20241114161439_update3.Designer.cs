﻿// <auto-generated />
using System;
using DuAnWebData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DuAnWebData.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241114161439_update3")]
    partial class update3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DuAnWebData.Model.Accounts", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountPass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountName")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Accountss");
                });

            modelBuilder.Entity("DuAnWebData.Model.Bill", b =>
                {
                    b.Property<Guid>("IdBill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdPay")
                        .HasColumnType("int");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayHoanthanh")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ToTal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdBill");

                    b.HasIndex("IdPay");

                    b.HasIndex("IdUser");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("DuAnWebData.Model.BillDetail", b =>
                {
                    b.Property<Guid>("IdBill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillIdBill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdBillDetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdBill");

                    b.HasIndex("BillIdBill");

                    b.HasIndex("IdProduct");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("DuAnWebData.Model.Cart", b =>
                {
                    b.Property<Guid>("IdCart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCart");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DuAnWebData.Model.CartDetail", b =>
                {
                    b.Property<int>("IdCartDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCartDetail"));

                    b.Property<Guid>("IdCart")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Idproduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayThemVao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCartDetail");

                    b.HasIndex("IdCart");

                    b.HasIndex("Idproduct");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("DuAnWebData.Model.Pay", b =>
                {
                    b.Property<int>("IdPay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPay"));

                    b.Property<string>("NamePay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPay");

                    b.ToTable("pays");
                });

            modelBuilder.Entity("DuAnWebData.Model.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescriptionProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceProduct")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DuAnWebData.Model.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRole"));

                    b.Property<string>("NameRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DuAnWebData.Model.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("AccountName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DuAnWebData.Model.Accounts", b =>
                {
                    b.HasOne("DuAnWebData.Model.Role", "role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("DuAnWebData.Model.Bill", b =>
                {
                    b.HasOne("DuAnWebData.Model.Pay", "Pay")
                        .WithMany("Bills")
                        .HasForeignKey("IdPay")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnWebData.Model.User", "User")
                        .WithMany("bills")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pay");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DuAnWebData.Model.BillDetail", b =>
                {
                    b.HasOne("DuAnWebData.Model.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("BillIdBill");

                    b.HasOne("DuAnWebData.Model.Product", "Product")
                        .WithMany("BillDetais")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DuAnWebData.Model.Cart", b =>
                {
                    b.HasOne("DuAnWebData.Model.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("DuAnWebData.Model.Cart", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DuAnWebData.Model.CartDetail", b =>
                {
                    b.HasOne("DuAnWebData.Model.Cart", "Cart")
                        .WithMany("cartDetails")
                        .HasForeignKey("IdCart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnWebData.Model.Product", "Product")
                        .WithMany("CartDetail")
                        .HasForeignKey("Idproduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DuAnWebData.Model.User", b =>
                {
                    b.HasOne("DuAnWebData.Model.Accounts", "Accounts")
                        .WithOne("user")
                        .HasForeignKey("DuAnWebData.Model.User", "AccountName")
                        .HasPrincipalKey("DuAnWebData.Model.Accounts", "AccountName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("DuAnWebData.Model.Accounts", b =>
                {
                    b.Navigation("user");
                });

            modelBuilder.Entity("DuAnWebData.Model.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("DuAnWebData.Model.Cart", b =>
                {
                    b.Navigation("cartDetails");
                });

            modelBuilder.Entity("DuAnWebData.Model.Pay", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("DuAnWebData.Model.Product", b =>
                {
                    b.Navigation("BillDetais");

                    b.Navigation("CartDetail");
                });

            modelBuilder.Entity("DuAnWebData.Model.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("DuAnWebData.Model.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("bills");
                });
#pragma warning restore 612, 618
        }
    }
}
