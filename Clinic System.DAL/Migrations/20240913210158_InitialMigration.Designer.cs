﻿// <auto-generated />
using System;
using Clinic_System.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinic_System.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240913210158_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clinic_System.DAL.Entities.Appointment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int?>("DeptID")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<bool>("Isbooked")
                        .HasColumnType("bit");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AppointmentID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Doctor", b =>
                {
                    b.HasBaseType("Clinic_System.DAL.Entities.User");

                    b.Property<int?>("DeptID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionPrice")
                        .HasColumnType("int");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.HasIndex("DeptID");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Patient", b =>
                {
                    b.HasBaseType("Clinic_System.DAL.Entities.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Appointment", b =>
                {
                    b.HasOne("Clinic_System.DAL.Entities.Department", null)
                        .WithMany("Appointments")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("Clinic_System.DAL.Entities.Doctor", null)
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorID");

                    b.HasOne("Clinic_System.DAL.Entities.Patient", null)
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Department", b =>
                {
                    b.HasOne("Clinic_System.DAL.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Payment", b =>
                {
                    b.HasOne("Clinic_System.DAL.Entities.Appointment", null)
                        .WithMany("payments")
                        .HasForeignKey("AppointmentID");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Doctor", b =>
                {
                    b.HasOne("Clinic_System.DAL.Entities.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DeptID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Appointment", b =>
                {
                    b.Navigation("payments");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Department", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Clinic_System.DAL.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
