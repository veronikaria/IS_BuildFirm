﻿// <auto-generated />
using System;
using IS_BuildFirm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IS_BuildFirm.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211118004224_AddColumnAddress")]
    partial class AddColumnAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("IS_BuildFirm.Models.Brigade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brigades");
                });

            modelBuilder.Entity("IS_BuildFirm.Models.Builder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BrigadeId")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SpecialityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrigadeId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Builders");
                });

            modelBuilder.Entity("IS_BuildFirm.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("BrigadeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BrigadeId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("IS_BuildFirm.Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("IS_BuildFirm.Models.Builder", b =>
                {
                    b.HasOne("IS_BuildFirm.Models.Brigade", "Brigade")
                        .WithMany()
                        .HasForeignKey("BrigadeId");

                    b.HasOne("IS_BuildFirm.Models.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId");

                    b.Navigation("Brigade");

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("IS_BuildFirm.Models.Schedule", b =>
                {
                    b.HasOne("IS_BuildFirm.Models.Brigade", "Brigade")
                        .WithMany()
                        .HasForeignKey("BrigadeId");

                    b.Navigation("Brigade");
                });
#pragma warning restore 612, 618
        }
    }
}
