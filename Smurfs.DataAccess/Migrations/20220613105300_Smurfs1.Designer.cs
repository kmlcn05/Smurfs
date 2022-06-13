﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smurfs.DataAccess.Concrete.Context;

#nullable disable

namespace Smurfs.DataAccess.Migrations
{
    [DbContext(typeof(SmurfsContext))]
    [Migration("20220613105300_Smurfs1")]
    partial class Smurfs1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Smurfs.Entities.Conrete.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Call", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Appointee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("CagriCozumSuresi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CallDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CallDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CallName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CallPriority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CallStatusId")
                        .HasColumnType("int");

                    b.Property<string>("JiraProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JiraProjectNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JiraTaskNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CallStatusId");

                    b.HasIndex("LogId");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.CallStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CallStatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CallStatus");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.DZDStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DZDStatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DZDStatuses");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Page")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.HasIndex("UsersId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Premium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Premiums");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ProcessName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Analyst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnalystManDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BankId")
                        .HasColumnType("int");

                    b.Property<int?>("DZDStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Developer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeveloperManDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JiraProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JiraProjectNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JiraTaskNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LogId")
                        .HasColumnType("int");

                    b.Property<string>("PmManDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProjectDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TotalManDay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("DZDStatusId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LogId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TeamId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("Active")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("DateOfStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("premiumId")
                        .HasColumnType("int");

                    b.Property<int?>("teamId")
                        .HasColumnType("int");

                    b.Property<int?>("usergroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("premiumId");

                    b.HasIndex("teamId");

                    b.HasIndex("usergroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Call", b =>
                {
                    b.HasOne("Smurfs.Entities.Conrete.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("Smurfs.Entities.Conrete.CallStatus", "CallStatus")
                        .WithMany()
                        .HasForeignKey("CallStatusId");

                    b.HasOne("Smurfs.Entities.Conrete.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogId");

                    b.Navigation("Bank");

                    b.Navigation("CallStatus");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Log", b =>
                {
                    b.HasOne("Smurfs.Entities.Conrete.Process", "Process")
                        .WithMany("Logs")
                        .HasForeignKey("ProcessId");

                    b.HasOne("Smurfs.Entities.Conrete.User", "Users")
                        .WithMany("Logs")
                        .HasForeignKey("UsersId");

                    b.Navigation("Process");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Project", b =>
                {
                    b.HasOne("Smurfs.Entities.Conrete.Bank", "Bank")
                        .WithMany("Project")
                        .HasForeignKey("BankId");

                    b.HasOne("Smurfs.Entities.Conrete.DZDStatus", "DZDStatus")
                        .WithMany("Project")
                        .HasForeignKey("DZDStatusId");

                    b.HasOne("Smurfs.Entities.Conrete.Department", "Department")
                        .WithMany("Project")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Smurfs.Entities.Conrete.Log", "Log")
                        .WithMany("Project")
                        .HasForeignKey("LogId");

                    b.HasOne("Smurfs.Entities.Conrete.Status", "Status")
                        .WithMany("Project")
                        .HasForeignKey("StatusId");

                    b.HasOne("Smurfs.Entities.Conrete.Team", "Team")
                        .WithMany("Project")
                        .HasForeignKey("TeamId");

                    b.Navigation("Bank");

                    b.Navigation("DZDStatus");

                    b.Navigation("Department");

                    b.Navigation("Log");

                    b.Navigation("Status");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.User", b =>
                {
                    b.HasOne("Smurfs.Entities.Conrete.Premium", "premium")
                        .WithMany("Users")
                        .HasForeignKey("premiumId");

                    b.HasOne("Smurfs.Entities.Conrete.Team", "team")
                        .WithMany("Users")
                        .HasForeignKey("teamId");

                    b.HasOne("Smurfs.Entities.Conrete.UserGroup", "usergroup")
                        .WithMany("Users")
                        .HasForeignKey("usergroupId");

                    b.Navigation("premium");

                    b.Navigation("team");

                    b.Navigation("usergroup");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Bank", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Department", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.DZDStatus", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Log", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Premium", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Process", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Status", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.Team", b =>
                {
                    b.Navigation("Project");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.User", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Smurfs.Entities.Conrete.UserGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
