﻿// <auto-generated />
using System;
using Hospital_Web_Project_Fall.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital_Web_Project_Fall.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231231202344_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.AnaBilimDali", b =>
                {
                    b.Property<int>("AnaBilimDaliID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnaBilimDaliID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnaBilimDaliID");

                    b.ToTable("AnaBilimDali");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Appointment", b =>
                {
                    b.Property<Guid>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DoktorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HastaUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Saat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentID");

                    b.HasIndex("DoktorId");

                    b.HasIndex("HastaUserID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Doktor", b =>
                {
                    b.Property<Guid>("DoktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DoktorAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorBrans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorSifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorSoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorUnvan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PoliklinikID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RolID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DoktorId");

                    b.HasIndex("PoliklinikID");

                    b.HasIndex("RolID");

                    b.ToTable("Doktor");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Poliklinik", b =>
                {
                    b.Property<Guid>("PoliklinikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AnaBilimDaliID")
                        .HasColumnType("int");

                    b.Property<int>("SiraNo")
                        .HasColumnType("int");

                    b.HasKey("PoliklinikID");

                    b.HasIndex("AnaBilimDaliID");

                    b.ToTable("Poliklinik");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Role", b =>
                {
                    b.Property<Guid>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RolAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RolAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RolID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("RolID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.WorkingHours", b =>
                {
                    b.Property<Guid>("WorkingHoursID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BaslangicSaat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BitisSaat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DoktorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gun")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkingHoursID");

                    b.HasIndex("DoktorId");

                    b.ToTable("WorkingHours");
                });

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Appointment", b =>
                {
                    b.HasOne("Hospital_Web_Project_Fall.Models.Domain.Doktor", "Doktor")
                        .WithMany("Randevular")
                        .HasForeignKey("DoktorId");

                    b.HasOne("Hospital_Web_Project_Fall.Models.Domain.User", "Hasta")
                        .WithMany("Randevular")
                        .HasForeignKey("HastaUserID");

                    b.Navigation("Doktor");

                    b.Navigation("Hasta");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Doktor", b =>
                {
                    b.HasOne("Hospital_Web_Project_Fall.Models.Domain.Poliklinik", "Poliklinik")
                        .WithMany("Doktorlar")
                        .HasForeignKey("PoliklinikID");

                    b.HasOne("Hospital_Web_Project_Fall.Models.Domain.Role", "Rol")
                        .WithMany()
                        .HasForeignKey("RolID");

                    b.Navigation("Poliklinik");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Poliklinik", b =>
                {
                    b.HasOne("Hospital_Web_Project_Fall.Models.Domain.AnaBilimDali", "AnaBilimDali")
                        .WithMany("Poliklinikler")
                        .HasForeignKey("AnaBilimDaliID");

                    b.Navigation("AnaBilimDali");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.User", b =>
                {
                    b.HasOne("Hospital_Web_Project_Fall.Models.Domain.Role", "Rol")
                        .WithMany("Kullanicilar")
                        .HasForeignKey("RolID");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.WorkingHours", b =>
                {
                    b.HasOne("Hospital_Web_Project_Fall.Models.Domain.Doktor", "Doktor")
                        .WithMany("CalismaSaatleri")
                        .HasForeignKey("DoktorId");

                    b.Navigation("Doktor");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.AnaBilimDali", b =>
                {
                    b.Navigation("Poliklinikler");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Doktor", b =>
                {
                    b.Navigation("CalismaSaatleri");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Poliklinik", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.Role", b =>
                {
                    b.Navigation("Kullanicilar");
                });

            modelBuilder.Entity("Hospital_Web_Project_Fall.Models.Domain.User", b =>
                {
                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
