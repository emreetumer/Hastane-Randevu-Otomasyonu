﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proje_odevi.Entities;

#nullable disable

namespace proje_odevi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231231184657_Randevularim3")]
    partial class Randevularim3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proje_odevi.Entities.Kullanici", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdSoyad")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilResmiDosyaAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Kullanıcılar");
                });

            modelBuilder.Entity("proje_odevi.Models.HekimViewModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alani")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorAdiSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RandevuViewModelRandevuId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RandevuViewModelRandevuId");

                    b.ToTable("Hekimler");
                });

            modelBuilder.Entity("proje_odevi.Models.KlinikViewModel", b =>
                {
                    b.Property<Guid>("KlinikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KlinikAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RandevuViewModelRandevuId")
                        .HasColumnType("int");

                    b.HasKey("KlinikId");

                    b.HasIndex("RandevuViewModelRandevuId");

                    b.ToTable("Klinikler");
                });

            modelBuilder.Entity("proje_odevi.Models.RandevuViewModel", b =>
                {
                    b.Property<int>("RandevuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuId"), 1L, 1);

                    b.Property<Guid>("SecilenDoktorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SecilenKlinikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("klinik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("RandevuId");

                    b.ToTable("Randevularim");
                });

            modelBuilder.Entity("proje_odevi.Models.HekimViewModel", b =>
                {
                    b.HasOne("proje_odevi.Models.RandevuViewModel", null)
                        .WithMany("Hekimler")
                        .HasForeignKey("RandevuViewModelRandevuId");
                });

            modelBuilder.Entity("proje_odevi.Models.KlinikViewModel", b =>
                {
                    b.HasOne("proje_odevi.Models.RandevuViewModel", null)
                        .WithMany("Klinikler")
                        .HasForeignKey("RandevuViewModelRandevuId");
                });

            modelBuilder.Entity("proje_odevi.Models.RandevuViewModel", b =>
                {
                    b.Navigation("Hekimler");

                    b.Navigation("Klinikler");
                });
#pragma warning restore 612, 618
        }
    }
}
