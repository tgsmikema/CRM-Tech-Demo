﻿// <auto-generated />
using System;
using CustomerRelationManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerRelationManager.Migrations
{
    [DbContext(typeof(CrmDBContext))]
    [Migration("20230331032448_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("CustomerRelationManager.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDateAndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerRelationManager.Model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AssignedToCustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignedToUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDateAndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDateAndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsTaskDone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskSummary")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("CustomerRelationManager.Model.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
