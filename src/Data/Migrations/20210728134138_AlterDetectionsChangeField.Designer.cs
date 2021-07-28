﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210728134138_AlterDetectionsChangeField")]
    partial class AlterDetectionsChangeField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Data.ECamera", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cameras");
                });

            modelBuilder.Entity("Data.EDetection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CameraId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Score")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.ToTable("Detections");
                });

            modelBuilder.Entity("Data.EDetection", b =>
                {
                    b.HasOne("Data.ECamera", "Camera")
                        .WithMany()
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");
                });
#pragma warning restore 612, 618
        }
    }
}