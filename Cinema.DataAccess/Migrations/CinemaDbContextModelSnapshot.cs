﻿// <auto-generated />
using System;
using Cinema.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.DataAccess.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Star")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.MoviePlanning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MovieTheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("MovieTheaterId");

                    b.ToTable("MoviePlannings");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.MovieTheater", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<Guid?>("SeatsMapsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeatsMapsId");

                    b.ToTable("MovieTheaters");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MoviePlanningId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MoviePlanningId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.Seats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Column")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<string>("Row")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SeatsMapId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeatsMapId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.SeatsMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("SeatsMaps");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.MoviePlanning", b =>
                {
                    b.HasOne("Cinema.ApplicationLogic.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("Cinema.ApplicationLogic.Models.MovieTheater", "MovieTheater")
                        .WithMany()
                        .HasForeignKey("MovieTheaterId");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.MovieTheater", b =>
                {
                    b.HasOne("Cinema.ApplicationLogic.Models.SeatsMap", "SeatsMaps")
                        .WithMany()
                        .HasForeignKey("SeatsMapsId");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.Reservation", b =>
                {
                    b.HasOne("Cinema.ApplicationLogic.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Cinema.ApplicationLogic.Models.MoviePlanning", "MoviePlanning")
                        .WithMany()
                        .HasForeignKey("MoviePlanningId");
                });

            modelBuilder.Entity("Cinema.ApplicationLogic.Models.Seats", b =>
                {
                    b.HasOne("Cinema.ApplicationLogic.Models.SeatsMap", null)
                        .WithMany("Seats")
                        .HasForeignKey("SeatsMapId");
                });
#pragma warning restore 612, 618
        }
    }
}
