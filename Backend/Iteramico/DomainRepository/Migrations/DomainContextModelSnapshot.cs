﻿// <auto-generated />
using System;
using DomainRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DomainRepository.Migrations
{
    [DbContext(typeof(DomainContext))]
    partial class DomainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainRepository.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("LocalName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DomainRepository.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("LocalName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DomainRepository.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int?>("JourneyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("JourneyId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DomainRepository.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("JourneyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("JourneyId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("DomainRepository.Models.ExpenseParticipation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ExpenseId")
                        .HasColumnType("int");

                    b.Property<int?>("PayerId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ExpenseId");

                    b.HasIndex("ExpenseId");

                    b.HasIndex("PayerId");

                    b.ToTable("ExpenseParticipations");
                });

            modelBuilder.Entity("DomainRepository.Models.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ToId");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("DomainRepository.Models.JourneyParticipation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("JourneyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "JourneyId");

                    b.HasIndex("JourneyId");

                    b.ToTable("JourneyParticipations");
                });

            modelBuilder.Entity("DomainRepository.Models.Memory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("ImageBase64")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JourneyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("JourneyId");

                    b.ToTable("Memories");
                });

            modelBuilder.Entity("DomainRepository.Models.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("ForId")
                        .HasColumnType("int");

                    b.Property<int>("JourneyId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ForId");

                    b.HasIndex("JourneyId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("DomainRepository.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasDefaultValue("");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasDefaultValue("");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasDefaultValue("");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DomainRepository.Models.City", b =>
                {
                    b.HasOne("DomainRepository.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DomainRepository.Models.Event", b =>
                {
                    b.HasOne("DomainRepository.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("DomainRepository.Models.Journey", "Journey")
                        .WithMany("Events")
                        .HasForeignKey("JourneyId");

                    b.Navigation("Creator");

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("DomainRepository.Models.Expense", b =>
                {
                    b.HasOne("DomainRepository.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("DomainRepository.Models.Journey", "Journey")
                        .WithMany("Expenses")
                        .HasForeignKey("JourneyId");

                    b.Navigation("Creator");

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("DomainRepository.Models.ExpenseParticipation", b =>
                {
                    b.HasOne("DomainRepository.Models.Expense", "Expense")
                        .WithMany("Participations")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainRepository.Models.User", "Payer")
                        .WithMany("Pays")
                        .HasForeignKey("PayerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DomainRepository.Models.User", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expense");

                    b.Navigation("Payer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DomainRepository.Models.Journey", b =>
                {
                    b.HasOne("DomainRepository.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DomainRepository.Models.City", "To")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("To");
                });

            modelBuilder.Entity("DomainRepository.Models.JourneyParticipation", b =>
                {
                    b.HasOne("DomainRepository.Models.Journey", "Journey")
                        .WithMany("Participations")
                        .HasForeignKey("JourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainRepository.Models.User", "User")
                        .WithMany("Participations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DomainRepository.Models.Memory", b =>
                {
                    b.HasOne("DomainRepository.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("DomainRepository.Models.Journey", "Journey")
                        .WithMany("Memories")
                        .HasForeignKey("JourneyId");

                    b.Navigation("Creator");

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("DomainRepository.Models.Reminder", b =>
                {
                    b.HasOne("DomainRepository.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DomainRepository.Models.User", "For")
                        .WithMany("Reminders")
                        .HasForeignKey("ForId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainRepository.Models.Journey", "Journey")
                        .WithMany("Reminders")
                        .HasForeignKey("JourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("For");

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("DomainRepository.Models.User", b =>
                {
                    b.OwnsOne("DomainRepository.Models.Auth", "Auth", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<int>("LoginAttempts")
                                .HasColumnType("int");

                            b1.Property<string>("PasswordHash")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<byte[]>("PasswordSalt")
                                .HasColumnType("varbinary(max)");

                            b1.Property<string>("Username")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("UserId");

                            b1.ToTable("Auth", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Auth")
                        .IsRequired();
                });

            modelBuilder.Entity("DomainRepository.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("DomainRepository.Models.Expense", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("DomainRepository.Models.Journey", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Expenses");

                    b.Navigation("Memories");

                    b.Navigation("Participations");

                    b.Navigation("Reminders");
                });

            modelBuilder.Entity("DomainRepository.Models.User", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Participations");

                    b.Navigation("Pays");

                    b.Navigation("Reminders");
                });
#pragma warning restore 612, 618
        }
    }
}
