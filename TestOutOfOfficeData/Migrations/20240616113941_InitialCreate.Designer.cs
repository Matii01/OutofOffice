﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestOutOfOfficeData;

#nullable disable

namespace TestOutOfOfficeData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240616113941_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6ddc9cec-043f-4cf4-a09e-a1635c556b09",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "82bde306-d74a-498a-850b-c7ed5b2e5b01",
                            Name = "HRManager",
                            NormalizedName = "HRMANAGER"
                        },
                        new
                        {
                            Id = "cbb40b0d-048c-4e46-b4b6-8912d146d1c6",
                            Name = "ProjectManager",
                            NormalizedName = "PROJECTMANAGER"
                        },
                        new
                        {
                            Id = "5ac784c4-ce4c-46ac-9de5-738511d27b90",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "b75aac86-370d-4bd8-a51c-e426591a4dd5",
                            RoleId = "6ddc9cec-043f-4cf4-a09e-a1635c556b09"
                        },
                        new
                        {
                            UserId = "a6d6def5-a80e-4c63-ac5a-07ec81797553",
                            RoleId = "82bde306-d74a-498a-850b-c7ed5b2e5b01"
                        },
                        new
                        {
                            UserId = "bb32cd38-9129-43ca-bb89-fcc0b5d6c1a3",
                            RoleId = "cbb40b0d-048c-4e46-b4b6-8912d146d1c6"
                        },
                        new
                        {
                            UserId = "b863d404-b85b-49cf-acf8-4f3e85d501bb",
                            RoleId = "5ac784c4-ce4c-46ac-9de5-738511d27b90"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TestOutOfOfficeData.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b75aac86-370d-4bd8-a51c-e426591a4dd5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3ee75824-baa5-4cc2-9f63-09cdd2bd10d1",
                            Email = "employee@example.com",
                            EmailConfirmed = true,
                            EmployeeId = 1,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                            NormalizedUserName = "EMPLOYEE@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEK540+jBj7QKyDJub2A84xwGisT+b01GNd0Oi52o1Fo11rg9NlDYQ5kLKY/7VU/Y0A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "employee@example.com"
                        },
                        new
                        {
                            Id = "a6d6def5-a80e-4c63-ac5a-07ec81797553",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d03fbf6c-4c43-4029-839b-9f3cb3d886af",
                            Email = "hrmanager@example.com",
                            EmailConfirmed = true,
                            EmployeeId = 2,
                            LockoutEnabled = false,
                            NormalizedEmail = "HRMANAGER@EXAMPLE.COM",
                            NormalizedUserName = "HRMANAGER@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFQ6VP39idQ4rZBa8HEFfRMtuTGjPak//GBKIMkrjr8ocYudnJFIZ0SrzerR78Owtg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "hrmanager@example.com"
                        },
                        new
                        {
                            Id = "bb32cd38-9129-43ca-bb89-fcc0b5d6c1a3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bf223602-5756-4e07-82c8-4b7d34af6913",
                            Email = "projectmanager@example.com",
                            EmailConfirmed = true,
                            EmployeeId = 3,
                            LockoutEnabled = false,
                            NormalizedEmail = "PROJECTMANAGER@EXAMPLE.COM",
                            NormalizedUserName = "PROJECTMANAGER@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOF81BuDB9RYGGXJ3y9/wHQ0opvkk3Io9dtHeJCcEixBh/JrCN83apCIiB/V9EGriA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "projectmanager@example.com"
                        },
                        new
                        {
                            Id = "b863d404-b85b-49cf-acf8-4f3e85d501bb",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "394621c1-5680-4428-bf35-6d67f2939d63",
                            Email = "administrator@example.com",
                            EmailConfirmed = true,
                            EmployeeId = 4,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRATOR@EXAMPLE.COM",
                            NormalizedUserName = "ADMINISTRATOR@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPHGeX/TOjK37VmZD0Dgr7EmRwS38AErxczV8wSsgknGZfGGTMtbytzOdR3CwZTDdQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "administrator@example.com"
                        });
                });

            modelBuilder.Entity("TestOutOfOfficeData.Lists.Employees.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutOfOfficeBalance")
                        .HasColumnType("int");

                    b.Property<int>("PeopleParthner")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Subdivision")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FullName = "Full Name",
                            OutOfOfficeBalance = 0,
                            PeopleParthner = 2,
                            Position = 0,
                            Status = 0,
                            Subdivision = 3
                        },
                        new
                        {
                            ID = 2,
                            FullName = "Test",
                            OutOfOfficeBalance = 0,
                            PeopleParthner = 0,
                            Position = 1,
                            Status = 0,
                            Subdivision = 0
                        },
                        new
                        {
                            ID = 3,
                            FullName = "Test",
                            OutOfOfficeBalance = 0,
                            PeopleParthner = 2,
                            Position = 2,
                            Status = 0,
                            Subdivision = 3
                        },
                        new
                        {
                            ID = 4,
                            FullName = "Test",
                            OutOfOfficeBalance = 0,
                            PeopleParthner = 2,
                            Position = 3,
                            Status = 0,
                            Subdivision = 5
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TestOutOfOfficeData.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TestOutOfOfficeData.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestOutOfOfficeData.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TestOutOfOfficeData.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestOutOfOfficeData.ApplicationUser", b =>
                {
                    b.HasOne("TestOutOfOfficeData.Lists.Employees.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}