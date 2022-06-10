﻿// <auto-generated />
using System;
using Lennt.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lennt.Model.Migrations
{
    [DbContext(typeof(LenntDbContext))]
    [Migration("20220610231613_Add Vacancies and vacancyType")]
    partial class AddVacanciesandvacancyType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Lennt.Model.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Lennt.Model.Entities.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int?>("Review")
                        .HasColumnType("integer");

                    b.Property<int?>("ReviewCount")
                        .HasColumnType("integer");

                    b.Property<string>("Skills")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Lennt.Model.Entities.Vacancy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Duration")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsApplied")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDoing")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("boolean");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("VacancyTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VacancyTypeId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("Lennt.Model.Entities.VacancyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VacancyTypes");
                });

            modelBuilder.Entity("Lennt.Model.Entities.Person", b =>
                {
                    b.HasOne("Lennt.Model.Entities.Category", "Category")
                        .WithMany("Persons")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Persons_Categories_CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Lennt.Model.Entities.Vacancy", b =>
                {
                    b.HasOne("Lennt.Model.Entities.Category", "Category")
                        .WithMany("Vacancies")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Vacancies_Categories_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lennt.Model.Entities.VacancyType", "VacancyType")
                        .WithMany("Vacancies")
                        .HasForeignKey("VacancyTypeId")
                        .HasConstraintName("FK_Vacancies_VacancyTypes_VacancyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("VacancyType");
                });

            modelBuilder.Entity("Lennt.Model.Entities.Category", b =>
                {
                    b.Navigation("Persons");

                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("Lennt.Model.Entities.VacancyType", b =>
                {
                    b.Navigation("Vacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
