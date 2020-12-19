﻿// <auto-generated />
using System;
using Db.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Db.API.Data
{
    [DbContext(typeof(ManualContext))]
    [Migration("20201219231928_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Db.Core.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Db.Core.Entities.BookMakes", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MakeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookId", "MakeId");

                    b.HasIndex("MakeId")
                        .IsUnique();

                    b.ToTable("BookMakes");
                });

            modelBuilder.Entity("Db.Core.Entities.FormatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FormatTypes");
                });

            modelBuilder.Entity("Db.Core.Entities.ImagePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("PositionX")
                        .HasColumnType("REAL");

                    b.Property<double>("PositionY")
                        .HasColumnType("REAL");

                    b.Property<int>("SectionPartsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SectionPartsId");

                    b.ToTable("ImagePoints");
                });

            modelBuilder.Entity("Db.Core.Entities.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("Db.Core.Entities.MakeModels", b =>
                {
                    b.Property<int>("MakeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearFrom")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearTo")
                        .HasColumnType("INTEGER");

                    b.HasKey("MakeId", "ModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("MakeModels");
                });

            modelBuilder.Entity("Db.Core.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Db.Core.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("MakersPartNumber")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Db.Core.Entities.Property", b =>
                {
                    b.Property<int>("PartId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyName")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("FormatTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyValue")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("PartId", "PropertyName");

                    b.HasIndex("FormatTypeId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Db.Core.Entities.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");
                });

            modelBuilder.Entity("Db.Core.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndPage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FigureDescription")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("FigureNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SectionHeader")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecificToModel")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<int>("StartPage")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Db.Core.Entities.SectionPartParents", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChildId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("SectionPartParents");
                });

            modelBuilder.Entity("Db.Core.Entities.SectionParts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("TEXT");

                    b.Property<int>("PageNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Reference")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Remarks")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("SectionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("SectionId");

                    b.ToTable("SectionParts");
                });

            modelBuilder.Entity("Db.Core.Entities.BookMakes", b =>
                {
                    b.HasOne("Db.Core.Entities.Book", "Book")
                        .WithMany("BookMakes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Core.Entities.Make", "Make")
                        .WithOne("ParentBook")
                        .HasForeignKey("Db.Core.Entities.BookMakes", "MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("Db.Core.Entities.ImagePoint", b =>
                {
                    b.HasOne("Db.Core.Entities.SectionParts", "SectionParts")
                        .WithMany()
                        .HasForeignKey("SectionPartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SectionParts");
                });

            modelBuilder.Entity("Db.Core.Entities.MakeModels", b =>
                {
                    b.HasOne("Db.Core.Entities.Make", "Make")
                        .WithMany("MakeModels")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Core.Entities.Model", "Model")
                        .WithMany("ParentMakes")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Db.Core.Entities.Property", b =>
                {
                    b.HasOne("Db.Core.Entities.FormatType", "FormatType")
                        .WithMany()
                        .HasForeignKey("FormatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Core.Entities.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Core.Entities.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormatType");

                    b.Navigation("Part");

                    b.Navigation("PropertyType");
                });

            modelBuilder.Entity("Db.Core.Entities.Section", b =>
                {
                    b.HasOne("Db.Core.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Db.Core.Entities.SectionPartParents", b =>
                {
                    b.HasOne("Db.Core.Entities.SectionParts", "Child")
                        .WithMany("ChildSections")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Core.Entities.SectionParts", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Db.Core.Entities.SectionParts", b =>
                {
                    b.HasOne("Db.Core.Entities.Part", "Part")
                        .WithMany("PartSections")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Core.Entities.Section", "Section")
                        .WithMany("SectionParts")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Db.Core.Entities.Book", b =>
                {
                    b.Navigation("BookMakes");
                });

            modelBuilder.Entity("Db.Core.Entities.Make", b =>
                {
                    b.Navigation("MakeModels");

                    b.Navigation("ParentBook")
                        .IsRequired();
                });

            modelBuilder.Entity("Db.Core.Entities.Model", b =>
                {
                    b.Navigation("ParentMakes");
                });

            modelBuilder.Entity("Db.Core.Entities.Part", b =>
                {
                    b.Navigation("PartSections");
                });

            modelBuilder.Entity("Db.Core.Entities.Section", b =>
                {
                    b.Navigation("SectionParts");
                });

            modelBuilder.Entity("Db.Core.Entities.SectionParts", b =>
                {
                    b.Navigation("ChildSections");
                });
#pragma warning restore 612, 618
        }
    }
}