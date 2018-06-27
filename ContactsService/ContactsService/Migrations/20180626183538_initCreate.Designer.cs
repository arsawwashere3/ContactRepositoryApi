﻿// <auto-generated />
using ContactsService.Contexts;
using ContactsService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ContactsService.Migrations
{
    [DbContext(typeof(ContactsDbContext))]
    [Migration("20180626183538_initCreate")]
    partial class initCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsService.Models.Address", b =>
                {
                    b.Property<int>("AddId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine")
                        .IsRequired();

                    b.Property<int?>("RegionId");

                    b.HasKey("AddId");

                    b.HasIndex("RegionId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ContactsService.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressAddId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<int>("Status");

                    b.HasKey("ContactId");

                    b.HasIndex("AddressAddId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactsService.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(160);

                    b.Property<string>("Country")
                        .HasMaxLength(160);

                    b.Property<string>("PostalCode");

                    b.Property<string>("State")
                        .HasMaxLength(160);

                    b.HasKey("RegionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("ContactsService.Models.UserKeys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserKey")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("UserKeys");
                });

            modelBuilder.Entity("ContactsService.Models.Address", b =>
                {
                    b.HasOne("ContactsService.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("ContactsService.Models.Contact", b =>
                {
                    b.HasOne("ContactsService.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressAddId");
                });
#pragma warning restore 612, 618
        }
    }
}
