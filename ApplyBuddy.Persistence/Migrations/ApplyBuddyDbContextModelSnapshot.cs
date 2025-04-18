﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ApplyBuddy.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApplyBuddy.Persistence.Migrations
{
    [DbContext(typeof(ApplyBuddyDbContext))]
    partial class ApplyBuddyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApplyBuddy.Domain.Aggregates.JobApplication.JobApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AppliedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("Position")
                        .HasColumnType("uuid");

                    b.Property<int?>("RecruiterId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecruiterId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("ApplyBuddy.Domain.Aggregates.JobApplication.Recruiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Agency")
                        .HasColumnType("text");

                    b.Property<string>("LinkedInProfile")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("Title")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Recruiter");
                });

            modelBuilder.Entity("ApplyBuddy.Domain.Aggregates.JobApplication.UserTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.PrimitiveCollection<List<string>>("Activites")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("JobApplicationId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JobApplicationId");

                    b.ToTable("UserTask");
                });

            modelBuilder.Entity("ApplyBuddy.Domain.Aggregates.Position.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("EmploymentType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Level")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ListedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.ComplexProperty<Dictionary<string, object>>("Salary", "ApplyBuddy.Domain.Aggregates.Position.Position.Salary#Salary", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<decimal?>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<int?>("Currency")
                                .HasColumnType("integer");

                            b1.Property<int?>("Type")
                                .HasColumnType("integer");
                        });

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("ApplyBuddy.Domain.Aggregates.JobApplication.JobApplication", b =>
                {
                    b.HasOne("ApplyBuddy.Domain.Aggregates.JobApplication.Recruiter", "Recruiter")
                        .WithMany()
                        .HasForeignKey("RecruiterId");

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("ApplyBuddy.Domain.Aggregates.JobApplication.UserTask", b =>
                {
                    b.HasOne("ApplyBuddy.Domain.Aggregates.JobApplication.JobApplication", null)
                        .WithMany("Tasks")
                        .HasForeignKey("JobApplicationId");
                });

            modelBuilder.Entity("ApplyBuddy.Domain.Aggregates.JobApplication.JobApplication", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
