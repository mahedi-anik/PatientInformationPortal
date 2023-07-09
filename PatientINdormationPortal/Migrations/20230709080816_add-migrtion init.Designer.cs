﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientInformationPortalAPI.Models;

#nullable disable

namespace PatientINdormationPortal.Migrations
{
    [DbContext(typeof(PatientInformationPortalDbContext))]
    [Migration("20230709080816_add-migrtion init")]
    partial class addmigrtioninit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment.Models.Disease", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"), 1L, 1);

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("DiseaseID");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("Assignment.Models.NCD", b =>
                {
                    b.Property<int>("NCDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDID"), 1L, 1);

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("NCDID");

                    b.ToTable("NCDs");
                });

            modelBuilder.Entity("Assignment.Models.NCD_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("NCDID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NCDID");

                    b.HasIndex("PatientID");

                    b.ToTable("NCD_Details");
                });

            modelBuilder.Entity("Assignment.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"), 1L, 1);

                    b.Property<int?>("DiseaseID")
                        .HasColumnType("int");

                    b.Property<string>("Epilepsy")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("PatientID");

                    b.HasIndex("DiseaseID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.Allergies", b =>
                {
                    b.Property<int>("AllergiesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergiesID"), 1L, 1);

                    b.Property<string>("AllergiesName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("AllergiesID");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.Allergies_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AllergiesID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AllergiesID");

                    b.HasIndex("PatientID");

                    b.ToTable("Allergies_Details");
                });

            modelBuilder.Entity("Assignment.Models.NCD_Details", b =>
                {
                    b.HasOne("Assignment.Models.NCD", "NCD")
                        .WithMany("NCD_Details")
                        .HasForeignKey("NCDID");

                    b.HasOne("Assignment.Models.Patient", "Patient")
                        .WithMany("NCD_Details")
                        .HasForeignKey("PatientID");

                    b.Navigation("NCD");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Assignment.Models.Patient", b =>
                {
                    b.HasOne("Assignment.Models.Disease", "Disease")
                        .WithMany("Patients")
                        .HasForeignKey("DiseaseID");

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.Allergies_Details", b =>
                {
                    b.HasOne("PatientInformationPortalAPI.Models.Allergies", "Allergies")
                        .WithMany("Allergies_Details")
                        .HasForeignKey("AllergiesID");

                    b.HasOne("Assignment.Models.Patient", "Patient")
                        .WithMany("Allergies_Details")
                        .HasForeignKey("PatientID");

                    b.Navigation("Allergies");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Assignment.Models.Disease", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Assignment.Models.NCD", b =>
                {
                    b.Navigation("NCD_Details");
                });

            modelBuilder.Entity("Assignment.Models.Patient", b =>
                {
                    b.Navigation("Allergies_Details");

                    b.Navigation("NCD_Details");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.Allergies", b =>
                {
                    b.Navigation("Allergies_Details");
                });
#pragma warning restore 612, 618
        }
    }
}
