﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppCa.ViewModels;

namespace WebAppCa.Migrations
{
    [DbContext(typeof(BroadCastContext))]
    [Migration("20181103232418_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppCa.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebAppCa.Models.Channel", b =>
                {
                    b.Property<int>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("ChannelId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("WebAppCa.Models.Programme", b =>
                {
                    b.Property<int>("ProgrammeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<int>("Length");

                    b.Property<string>("Title");

                    b.HasKey("ProgrammeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Programmes");
                });

            modelBuilder.Entity("WebAppCa.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AirDate");

                    b.Property<int>("ChannelId");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<string>("Image");

                    b.Property<int>("ProgrammeId");

                    b.Property<int>("Sorting");

                    b.Property<TimeSpan>("StartTime");

                    b.HasKey("ScheduleId");

                    b.HasIndex("ChannelId");

                    b.HasIndex("ProgrammeId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("WebAppCa.Models.Programme", b =>
                {
                    b.HasOne("WebAppCa.Models.Category", "Category")
                        .WithMany("Programmes")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("WebAppCa.Models.Schedule", b =>
                {
                    b.HasOne("WebAppCa.Models.Channel", "Channel")
                        .WithMany("Schedules")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAppCa.Models.Programme", "Programme")
                        .WithMany("Schedules")
                        .HasForeignKey("ProgrammeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
