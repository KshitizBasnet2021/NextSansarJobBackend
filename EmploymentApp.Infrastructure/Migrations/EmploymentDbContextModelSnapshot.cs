﻿// <auto-generated />
using System;
using EmploymentApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmploymentApp.Infrastructure.Migrations
{
    [DbContext(typeof(EmploymentDbContext))]
    partial class EmploymentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmploymentApp.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EmploymentApp.Core.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("JobId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<decimal?>("Lat")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("Long")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.Property<int>("TypeScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("EmploymentApp.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(17)")
                        .HasMaxLength(17)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EmploymentApp.Core.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StatusId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("EmploymentApp.Core.Entities.TypeSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TypeScheduleId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("TypeSchedule");
                });

            modelBuilder.Entity("EmploymentApp.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Bithdate")
                        .HasColumnType("date");

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Surnames")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EmploymentApp.Core.Entities.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserLoginId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("idx_email");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("EmploymentApp.Core.Entities.Job", b =>
                {
                    b.HasOne("EmploymentApp.Core.Entities.Category", "Category")
                        .WithMany("Job")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_JOB_CATEGORY")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmploymentApp.Core.Entities.Status", "Status")
                        .WithMany("Job")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_JOB_STATUS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmploymentApp.Core.Entities.TypeSchedule", "TypeSchedule")
                        .WithMany("Job")
                        .HasForeignKey("TypeScheduleId")
                        .HasConstraintName("FK_JOB_TYPESHEDULE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmploymentApp.Core.Entities.User", "User")
                        .WithMany("Job")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_JOB_USER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmploymentApp.Core.Entities.UserLogin", b =>
                {
                    b.HasOne("EmploymentApp.Core.Entities.Role", "Role")
                        .WithMany("UserLogin")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_USERLOGIN_ROLE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmploymentApp.Core.Entities.User", "User")
                        .WithMany("UserLogin")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_USERLOGIN_USER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
