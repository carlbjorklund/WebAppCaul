﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppCa.Models;

namespace WebAppCa.Migrations
{
    [DbContext(typeof(BroadCastContext))]
    partial class BroadCastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

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

                    b.Property<int?>("MyChannelViewModelMyChannelsId");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("ChannelId");

                    b.HasIndex("MyChannelViewModelMyChannelsId");

                    b.HasIndex("UserId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("WebAppCa.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<DateTime>("IssueDate");

                    b.Property<string>("Title");

                    b.HasKey("NewsId");

                    b.ToTable("News");
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

                    b.Property<int?>("MyProgrammesViewModelMyProgrammeId");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("ProgrammeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MyProgrammesViewModelMyProgrammeId");

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("WebAppCa.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebAppCa.ViewModels.MyChannelViewModel", b =>
                {
                    b.Property<int>("MyChannelsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserID");

                    b.Property<string>("UserName");

                    b.HasKey("MyChannelsId");

                    b.ToTable("MyChannelViewModel");
                });

            modelBuilder.Entity("WebAppCa.ViewModels.MyProgrammesViewModel", b =>
                {
                    b.Property<int>("MyProgrammeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserID");

                    b.Property<string>("UserName");

                    b.HasKey("MyProgrammeId");

                    b.ToTable("MyProgrammes");
                });

            modelBuilder.Entity("WebAppCa.ViewModels.MySchedule", b =>
                {
                    b.Property<int>("MyScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ScheduleID");

                    b.Property<string>("UserId");

                    b.Property<int?>("UserId1");

                    b.Property<string>("UserName");

                    b.HasKey("MyScheduleId");

                    b.HasIndex("ScheduleID");

                    b.HasIndex("UserId1");

                    b.ToTable("MySchedules");
                });

            modelBuilder.Entity("WebAppCa.ViewModels.MyStuffViewModel", b =>
                {
                    b.Property<int>("MyStuffID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AirDate");

                    b.Property<int>("CategoryId");

                    b.Property<string>("CategoryName");

                    b.Property<string>("ChannelName");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<int>("Length");

                    b.Property<string>("ProgrameDescription");

                    b.Property<string>("ProgrameName");

                    b.Property<int>("ScheduleId");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<string>("UserName");

                    b.Property<string>("UserStuffUserID");

                    b.HasKey("MyStuffID");

                    b.HasIndex("UserStuffUserID");

                    b.ToTable("MyStuffViewModel");
                });

            modelBuilder.Entity("WebAppCa.ViewModels.ScheduleViewModel", b =>
                {
                    b.Property<int>("ScheduleViewModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AirDate");

                    b.Property<int>("CategoryId");

                    b.Property<string>("CategoryName");

                    b.Property<string>("ChannelName");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<int>("Length");

                    b.Property<string>("ProgrameDescription");

                    b.Property<string>("ProgrameName");

                    b.Property<TimeSpan>("StartTime");

                    b.HasKey("ScheduleViewModelId");

                    b.ToTable("ScheduleViewModel");
                });

            modelBuilder.Entity("WebAppCa.ViewModels.UserStuff", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("UserStuff");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAppCa.Models.Channel", b =>
                {
                    b.HasOne("WebAppCa.ViewModels.MyChannelViewModel")
                        .WithMany("MyChannels")
                        .HasForeignKey("MyChannelViewModelMyChannelsId");

                    b.HasOne("WebAppCa.Models.User")
                        .WithMany("MyChannels")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebAppCa.Models.Programme", b =>
                {
                    b.HasOne("WebAppCa.Models.Category", "Category")
                        .WithMany("Programmes")
                        .HasForeignKey("CategoryId");

                    b.HasOne("WebAppCa.ViewModels.MyProgrammesViewModel")
                        .WithMany("MyProgrammes")
                        .HasForeignKey("MyProgrammesViewModelMyProgrammeId");

                    b.HasOne("WebAppCa.Models.User")
                        .WithMany("MyProgrammes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebAppCa.Models.Schedule", b =>
                {
                    b.HasOne("WebAppCa.Models.Channel", "Channel")
                        .WithMany()
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAppCa.Models.Programme", "Programme")
                        .WithMany("Schedules")
                        .HasForeignKey("ProgrammeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAppCa.ViewModels.MySchedule", b =>
                {
                    b.HasOne("WebAppCa.Models.Schedule", "Schedule")
                        .WithMany("MySchedules")
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAppCa.Models.User", "User")
                        .WithMany("MySchedules")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("WebAppCa.ViewModels.MyStuffViewModel", b =>
                {
                    b.HasOne("WebAppCa.ViewModels.UserStuff")
                        .WithMany("myStuffs")
                        .HasForeignKey("UserStuffUserID");
                });
#pragma warning restore 612, 618
        }
    }
}
