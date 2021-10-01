﻿// <auto-generated />
using System;
using ContactsApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactsApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210930013027_ConfigureNewGuid")]
    partial class ConfigureNewGuid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsApi.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("39f51b4a-f7c6-487a-b6a3-cec178eb7c22"),
                            Company = "DevWorking",
                            Email = "nalvarez23@live.com.ar",
                            FirstName = "Nahuel",
                            LastName = "Alvarez",
                            PhoneNumber = "+543794637353"
                        },
                        new
                        {
                            Id = new Guid("f5331dd7-41e4-4df8-b3a3-7909022b16f6"),
                            Company = "Development",
                            Email = "test@gmail.com",
                            FirstName = "Test",
                            LastName = "Test",
                            PhoneNumber = "+111111111111"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
