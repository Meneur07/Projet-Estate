﻿// <auto-generated />
using System;
using EstateManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstateManager.Migrations
{
    [DbContext(typeof(EstateManagerContext))]
    partial class EstateManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("EstateManager.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Person1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Person2Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reason")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Person1Id");

                    b.HasIndex("Person2Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("EstateManager.Models.Estate", b =>
                {
                    b.Property<int>("Reference")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("BathroomCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarbonFootPrint")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int>("CommercialId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnergeticPerformance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FloorCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Surface")
                        .HasColumnType("REAL");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Reference");

                    b.HasIndex("CommercialId");

                    b.ToTable("Estates");
                });

            modelBuilder.Entity("EstateManager.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("CellPhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EstateManager.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("BLOB");

                    b.Property<int>("Reference")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ShootingDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("Reference");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("EstateManager.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EstateManager.Models.TagEstate", b =>
                {
                    b.Property<int>("EstateReference")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EstateReference", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TagEstates");
                });

            modelBuilder.Entity("EstateManager.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("Fees")
                        .HasColumnType("REAL");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Reference")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("Reference");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("EstateManager.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EstateManager.Models.Appointment", b =>
                {
                    b.HasOne("EstateManager.Models.Person", "Person1")
                        .WithMany()
                        .HasForeignKey("Person1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstateManager.Models.Person", "Person2")
                        .WithMany()
                        .HasForeignKey("Person2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstateManager.Models.Estate", b =>
                {
                    b.HasOne("EstateManager.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("CommercialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstateManager.Models.Photo", b =>
                {
                    b.HasOne("EstateManager.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstateManager.Models.Estate", "Estate")
                        .WithMany("Photos")
                        .HasForeignKey("Reference")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstateManager.Models.TagEstate", b =>
                {
                    b.HasOne("EstateManager.Models.Estate", "Estate")
                        .WithMany()
                        .HasForeignKey("EstateReference")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstateManager.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstateManager.Models.Transaction", b =>
                {
                    b.HasOne("EstateManager.Models.Person", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstateManager.Models.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstateManager.Models.Estate", "Estate")
                        .WithMany()
                        .HasForeignKey("Reference")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstateManager.Models.User", b =>
                {
                    b.HasOne("EstateManager.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
