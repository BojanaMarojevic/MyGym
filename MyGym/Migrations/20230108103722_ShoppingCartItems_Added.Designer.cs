﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyGym.Data;

namespace MyGym.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230108103722_ShoppingCartItems_Added")]
    partial class ShoppingCartItems_Added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MyGym.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("MyGym.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("MyGym.Models.Equipment_Training", b =>
                {
                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId", "TrainingId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Equipments_Trainings");
                });

            modelBuilder.Entity("MyGym.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyGym.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TrainingId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("MyGym.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("MyGym.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainingCategory")
                        .HasColumnType("int");

                    b.Property<int>("TrainingCenterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("TrainingCenterId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("MyGym.Models.TrainingCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingCenters");
                });

            modelBuilder.Entity("MyGym.Models.Equipment_Training", b =>
                {
                    b.HasOne("MyGym.Models.Equipment", "Equipment")
                        .WithMany("Equipments_Trainings")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyGym.Models.Training", "Training")
                        .WithMany("Equipments_Trainings")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("MyGym.Models.OrderItem", b =>
                {
                    b.HasOne("MyGym.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyGym.Models.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("MyGym.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("MyGym.Models.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("MyGym.Models.Training", b =>
                {
                    b.HasOne("MyGym.Models.Coach", "Coach")
                        .WithMany("Trainings")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyGym.Models.TrainingCenter", "TrainingCenter")
                        .WithMany("Trainings")
                        .HasForeignKey("TrainingCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("TrainingCenter");
                });

            modelBuilder.Entity("MyGym.Models.Coach", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("MyGym.Models.Equipment", b =>
                {
                    b.Navigation("Equipments_Trainings");
                });

            modelBuilder.Entity("MyGym.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MyGym.Models.Training", b =>
                {
                    b.Navigation("Equipments_Trainings");
                });

            modelBuilder.Entity("MyGym.Models.TrainingCenter", b =>
                {
                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}