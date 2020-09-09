﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using roomies.Models;

namespace roomies.Migrations
{
    [DbContext(typeof(RoomiesDbContext))]
    [Migration("20200905084536_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("roomies.Models.Address", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlatNo")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("roomies.Models.Filter", b =>
                {
                    b.Property<int>("FilterId")
                        .HasColumnType("int");

                    b.Property<float>("MaxBudget")
                        .HasColumnType("real");

                    b.Property<int>("MaxRoomCount")
                        .HasColumnType("int");

                    b.Property<int>("MaxSharingCount")
                        .HasColumnType("int");

                    b.Property<float>("MinBudget")
                        .HasColumnType("real");

                    b.Property<int>("MinRoomCount")
                        .HasColumnType("int");

                    b.Property<int>("MinSharingCount")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("FilterId");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("roomies.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Rent")
                        .HasColumnType("real");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<int>("SharingCount")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("ValidateStatus")
                        .HasColumnType("int");

                    b.Property<int>("VisiblityStatus")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("roomies.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("roomies.Models.UserRoom", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("UserRooms");
                });

            modelBuilder.Entity("roomies.Models.Address", b =>
                {
                    b.HasOne("roomies.Models.Room", "room")
                        .WithOne("Location")
                        .HasForeignKey("roomies.Models.Address", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("roomies.Models.Filter", b =>
                {
                    b.HasOne("roomies.Models.User", "User")
                        .WithOne("Filter")
                        .HasForeignKey("roomies.Models.Filter", "FilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("roomies.Models.Room", b =>
                {
                    b.HasOne("roomies.Models.User", "Owner")
                        .WithMany("Rooms")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("roomies.Models.UserRoom", b =>
                {
                    b.HasOne("roomies.Models.Room", "Room")
                        .WithMany("Requests")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("roomies.Models.User", "User")
                        .WithMany("RequstedRooms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
