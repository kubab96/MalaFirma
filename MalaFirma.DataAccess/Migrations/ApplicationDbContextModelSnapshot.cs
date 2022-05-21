﻿// <auto-generated />
using System;
using MalaFirma.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MalaFirma.Models.Odpowiedz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPytania")
                        .HasColumnType("int");

                    b.Property<int>("PytanieId")
                        .HasColumnType("int");

                    b.Property<bool>("Wartosc")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PytanieId");

                    b.ToTable("Odpowiedzi");
                });

            modelBuilder.Entity("MalaFirma.Models.Proces", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wymaganie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZamowienieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("Procesy");
                });

            modelBuilder.Entity("MalaFirma.Models.Pytanie", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pytania");
                });

            modelBuilder.Entity("MalaFirma.Models.Zamowienie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataZamowienia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Potwierdzenie")
                        .HasColumnType("bit");

                    b.Property<string>("UwagiZamowienia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("MalaFirma.Models.Odpowiedz", b =>
                {
                    b.HasOne("MalaFirma.Models.Pytanie", "Pytanie")
                        .WithMany()
                        .HasForeignKey("PytanieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pytanie");
                });

            modelBuilder.Entity("MalaFirma.Models.Proces", b =>
                {
                    b.HasOne("MalaFirma.Models.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("ZamowienieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zamowienie");
                });
#pragma warning restore 612, 618
        }
    }
}
