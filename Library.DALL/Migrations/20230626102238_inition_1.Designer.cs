﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Library.DALL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.DALL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230626102238_inition_1")]
    partial class inition_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library.Domain.Models.AvailableBooks", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("IdBook")
                        .HasColumnType("integer");

                    b.Property<List<int>>("IdReader")
                        .HasColumnType("integer[]");

                    b.HasKey("id");

                    b.ToTable("DbAvailableBooks");
                });

            modelBuilder.Entity("Library.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgePublic")
                        .HasColumnType("integer");

                    b.Property<string>("Arc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CounBook")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DbBooks");
                });

            modelBuilder.Entity("Library.Domain.Models.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("YearBirth")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("DbReader");
                });
#pragma warning restore 612, 618
        }
    }
}
