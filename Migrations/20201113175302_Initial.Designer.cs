﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Term_Project_Version_1.Models;

namespace Term_Project_Version_1.Migrations
{
    [DbContext(typeof(SeekingAllahContext))]
    [Migration("20201113175302_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Term_Project_Version_1.Models.Members", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnName("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Pastoor Celensstraat 1",
                            City = "Kalmthout",
                            Country = "Belgium",
                            PostalCode = "2920",
                            email = "michelle@vanwetteregroup.com",
                            name = "Michelle Vanwettere"
                        },
                        new
                        {
                            ID = 2,
                            Address = "Mohammed Mohammed Amr Allah",
                            City = "Alexandria",
                            Country = "Egypt",
                            PostalCode = "21624",
                            email = "tito.nugaily@gmail.com",
                            name = "Tito Nugauily"
                        },
                        new
                        {
                            ID = 3,
                            City = "New York City",
                            Country = "United States",
                            PostalCode = "10001",
                            email = "david.wood@acts17.com",
                            name = "David Wood"
                        },
                        new
                        {
                            ID = 4,
                            Address = "4138 Huntington Drive",
                            City = "Traverse City",
                            Country = "United States",
                            PostalCode = "49686",
                            email = "mgibson@makeitrain.com",
                            name = "Matthew Gibson"
                        },
                        new
                        {
                            ID = 5,
                            Address = "4131 Benedict Canyon Dr",
                            City = "Los Angeles",
                            Country = "United States",
                            PostalCode = "91423",
                            email = "mohamedayew@gmail.com",
                            name = "Mohamed Ayew"
                        },
                        new
                        {
                            ID = 6,
                            Address = "1219 Tetreau Street",
                            City = "Thibodaux",
                            Country = "United States",
                            PostalCode = "70301",
                            email = "mayadamohamed@gmail.com",
                            name = "Meda Doyle"
                        });
                });

            modelBuilder.Entity("Term_Project_Version_1.Models.Purchases", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MembersID")
                        .HasColumnType("int");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MembersID");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            ID = "SA",
                            Description = "Seeking Allah Finding Jesus Paperback",
                            MembersID = 1,
                            Price = "$19.99"
                        },
                        new
                        {
                            ID = "SG",
                            Description = "Study Guide including hard cover book, study guide and blu-ray",
                            MembersID = 6,
                            Price = "$79.99"
                        },
                        new
                        {
                            ID = "FA",
                            Description = "Full Access including study guide and access to all podcasts and articles",
                            MembersID = 5,
                            Price = "$109.99"
                        });
                });

            modelBuilder.Entity("Term_Project_Version_1.Models.Purchases", b =>
                {
                    b.HasOne("Term_Project_Version_1.Models.Members", "Members")
                        .WithMany()
                        .HasForeignKey("MembersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
