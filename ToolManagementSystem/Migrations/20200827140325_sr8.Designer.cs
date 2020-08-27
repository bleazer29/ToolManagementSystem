﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToolManagementSystem.Shared.Data;

namespace ToolManagementSystem.Client.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200827140325_sr8")]
    partial class sr8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToolManagementSystem.Shared.Models.EmployeeRoles", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeRole");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            EmployeeId = 1
                        });
                });

            modelBuilder.Entity("ToolManagementSystem.Shared.Models.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "Admin",
                            BirthDate = new DateTime(2020, 8, 27, 17, 3, 21, 313, DateTimeKind.Local).AddTicks(9425),
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "admin",
                            Patronymic = "admin",
                            Phone = "00-000-00-00",
                            Question = "Who are you?",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("ToolManagementSystem.Shared.Models.Pages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NamePage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Page");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NamePage = "Page1"
                        },
                        new
                        {
                            Id = 2,
                            NamePage = "Page2"
                        },
                        new
                        {
                            Id = 3,
                            NamePage = "Page3"
                        });
                });

            modelBuilder.Entity("ToolManagementSystem.Shared.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("ToolManagementSystem.Shared.Models.RolesPages", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("PagesId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "PagesId");

                    b.HasIndex("PagesId");

                    b.ToTable("RolesPage");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            PagesId = 1
                        },
                        new
                        {
                            RoleId = 1,
                            PagesId = 2
                        },
                        new
                        {
                            RoleId = 1,
                            PagesId = 3
                        });
                });

            modelBuilder.Entity("ToolManagementSystem.Shared.Models.EmployeeRoles", b =>
                {
                    b.HasOne("ToolManagementSystem.Shared.Models.Employees", "Employe")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToolManagementSystem.Shared.Models.Roles", "Role")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToolManagementSystem.Shared.Models.RolesPages", b =>
                {
                    b.HasOne("ToolManagementSystem.Shared.Models.Pages", "Pages")
                        .WithMany("RolesPages")
                        .HasForeignKey("PagesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ToolManagementSystem.Shared.Models.Roles", "Roles")
                        .WithMany("RolesPages")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
