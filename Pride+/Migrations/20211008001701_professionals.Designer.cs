﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pride_;

namespace Pride_.Migrations
{
    [DbContext(typeof(PrideMoreContext))]
    [Migration("20211008001701_professionals")]
    partial class professionals
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Pride_.Domain.ProfessionalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("text");

                    b.Property<string>("Especialidade")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProfessionalType");
                });

            modelBuilder.Entity("Pride_.Domain.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Instagram")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Pride_.Domain.Patient", b =>
                {
                    b.HasBaseType("Pride_.Domain.User");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("Pride_.Domain.Professional", b =>
                {
                    b.HasBaseType("Pride_.Domain.User");

                    b.Property<string>("HealthInsurance")
                        .HasColumnType("text");

                    b.Property<int?>("ProfessionalTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Register")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("ProfessionalTypeId");

                    b.HasDiscriminator().HasValue("Professional");
                });

            modelBuilder.Entity("Pride_.Domain.Professional", b =>
                {
                    b.HasOne("Pride_.Domain.ProfessionalType", "ProfessionalType")
                        .WithMany()
                        .HasForeignKey("ProfessionalTypeId");

                    b.Navigation("ProfessionalType");
                });
#pragma warning restore 612, 618
        }
    }
}