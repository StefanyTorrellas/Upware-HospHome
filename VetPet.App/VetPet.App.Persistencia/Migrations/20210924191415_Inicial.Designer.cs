﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetPet.App.Persistencia;

namespace VetPet.App.Persistencia.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210924191415_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("VetPet.App.Dominio.Cita", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("fecha")
                        .HasColumnType("longtext");

                    b.Property<string>("hora")
                        .HasColumnType("longtext");

                    b.Property<int>("mascota_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("VetPet.App.Dominio.HistoriaClinica", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("anotaciones")
                        .HasColumnType("longtext");

                    b.Property<string>("cita_id")
                        .HasColumnType("longtext");

                    b.Property<int>("mascota_id")
                        .HasColumnType("int");

                    b.Property<int>("medicamento")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("HistoriasClinicas");
                });

            modelBuilder.Entity("VetPet.App.Dominio.Mascota", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.Property<int>("propietario_id")
                        .HasColumnType("int");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("VetPet.App.Dominio.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("cedula")
                        .HasColumnType("int");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<int>("genero")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("cedula")
                        .IsUnique();

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("VetPet.App.Dominio.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("VetPet.App.Dominio.Propietario", b =>
                {
                    b.HasBaseType("VetPet.App.Dominio.Persona");

                    b.Property<string>("ciudad")
                        .HasColumnType("longtext");

                    b.Property<string>("direccion")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Propietario");
                });

            modelBuilder.Entity("VetPet.App.Dominio.Admin", b =>
                {
                    b.HasBaseType("VetPet.App.Dominio.Usuario");

                    b.Property<int>("key")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Admin");
                });
#pragma warning restore 612, 618
        }
    }
}
