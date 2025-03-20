﻿// <auto-generated />
using System;
using LearnDotNetConsole.Databases.EntityFrameworkCore;
using LearnDotNetConsole.Databases.EntityFrameworkCore.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearnDotNetConsole.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    partial class PostgresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LearnDotNetConsole.Databases.EntityFrameworkCore.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasDiscriminator<string>("PaymentType").HasValue("Payment");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LearnDotNetConsole.Databases.EntityFrameworkCore.CreditCardPayment", b =>
                {
                    b.HasBaseType("LearnDotNetConsole.Databases.EntityFrameworkCore.Payment");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Credit");
                });

            modelBuilder.Entity("LearnDotNetConsole.Databases.EntityFrameworkCore.PayoneerPayment", b =>
                {
                    b.HasBaseType("LearnDotNetConsole.Databases.EntityFrameworkCore.Payment");

                    b.Property<string>("PayoneerEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Payoneer");
                });
#pragma warning restore 612, 618
        }
    }
}
