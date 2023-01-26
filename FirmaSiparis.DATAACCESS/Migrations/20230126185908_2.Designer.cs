﻿// <auto-generated />
using System;
using FirmaSiparis.DATAACCESS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirmaSiparis.DATAACCESS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230126185908_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FirmaSiparis.ENTITIES.Entities.Firma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Zamanı");

                    b.Property<string>("FirmaAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncellenme Zamanı");

                    b.Property<bool>("OnayDurumu")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("SiparisIzinBasSaati")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("SiparisIzinBitisSaati")
                        .HasColumnType("time");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Firmalar");
                });

            modelBuilder.Entity("FirmaSiparis.ENTITIES.Entities.Siparis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Zamanı");

                    b.Property<Guid>("FirmaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncellenme Zamanı");

                    b.Property<DateTime>("SiparisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("SiparisiVereninAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UrunId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.HasIndex("UrunId");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("FirmaSiparis.ENTITIES.Entities.Urun", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Zamanı");

                    b.Property<Guid>("FirmaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncellenme Zamanı");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("FirmaSiparis.ENTITIES.Entities.Siparis", b =>
                {
                    b.HasOne("FirmaSiparis.ENTITIES.Entities.Firma", "Firma")
                        .WithMany("Siparisler")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FirmaSiparis.ENTITIES.Entities.Urun", "Urun")
                        .WithMany("Siparisler")
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Firma");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("FirmaSiparis.ENTITIES.Entities.Urun", b =>
                {
                    b.HasOne("FirmaSiparis.ENTITIES.Entities.Firma", "Firma")
                        .WithMany("Urunler")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Firma");
                });

            modelBuilder.Entity("FirmaSiparis.ENTITIES.Entities.Firma", b =>
                {
                    b.Navigation("Siparisler");

                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("FirmaSiparis.ENTITIES.Entities.Urun", b =>
                {
                    b.Navigation("Siparisler");
                });
#pragma warning restore 612, 618
        }
    }
}
