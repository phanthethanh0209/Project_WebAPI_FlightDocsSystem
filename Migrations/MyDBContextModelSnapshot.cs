﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheThanh_WebAPI_Flight.Data;

#nullable disable

namespace TheThanh_WebAPI_Flight.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Document", b =>
                {
                    b.Property<int>("DocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocID"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("DocName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("DocID");

                    b.HasIndex("FlightID");

                    b.HasIndex("TypeID");

                    b.HasIndex("UserID");

                    b.ToTable("Document", (string)null);
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.DocumentType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeID"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TypeID");

                    b.HasIndex("UserID");

                    b.ToTable("DocumentType", (string)null);
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightID"), 1L, 1);

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PointLoad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointUnload")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalDoc")
                        .HasColumnType("int");

                    b.HasKey("FlightID");

                    b.HasIndex("FlightNo")
                        .IsUnique();

                    b.ToTable("Flight", (string)null);
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Permission", b =>
                {
                    b.Property<int>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionID");

                    b.ToTable("Permission", (string)null);

                    b.HasData(
                        new
                        {
                            PermissionID = 1,
                            Name = "Read Only"
                        },
                        new
                        {
                            PermissionID = 2,
                            Name = "Read and modify"
                        },
                        new
                        {
                            PermissionID = 3,
                            Name = "Full permission"
                        });
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IsssueAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("JwtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin",
                            Note = "Dành cho quản trị viên"
                        });
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RoleDocument", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.Property<int>("DocID")
                        .HasColumnType("int");

                    b.HasKey("RoleID", "PermissionID", "DocID");

                    b.HasIndex("DocID");

                    b.ToTable("RoleDocument", (string)null);
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RoleDocumentType", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("RoleID", "PermissionID", "TypeID");

                    b.HasIndex("TypeID");

                    b.ToTable("RoleDocumentType", (string)null);
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RolePermission", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.HasKey("RoleID", "PermissionID");

                    b.HasIndex("PermissionID");

                    b.ToTable("RolePermission", (string)null);

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            PermissionID = 3
                        });
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RoleUser", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("RoleID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("RoleUser", (string)null);

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            UserID = 1
                        });
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "thanh@vietjetair.com",
                            Password = "$2a$11$qse3/LUTWo8.qJwnMLI/0eRn.9tIrHP5nn/FUnFfrI7PZSY.yEXRi",
                            Phone = "0147852369",
                            UserName = "TheThanh29"
                        });
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Document", b =>
                {
                    b.HasOne("TheThanh_WebAPI_Flight.Data.Flight", "Flights")
                        .WithMany("Documents")
                        .HasForeignKey("FlightID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheThanh_WebAPI_Flight.Data.DocumentType", "DocumentTypes")
                        .WithMany("Documents")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheThanh_WebAPI_Flight.Data.User", "Users")
                        .WithMany("Documents")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DocumentTypes");

                    b.Navigation("Flights");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.DocumentType", b =>
                {
                    b.HasOne("TheThanh_WebAPI_Flight.Data.User", "Users")
                        .WithMany("DocumentTypes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RefreshToken", b =>
                {
                    b.HasOne("TheThanh_WebAPI_Flight.Data.User", "Users")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RoleDocument", b =>
                {
                    b.HasOne("TheThanh_WebAPI_Flight.Data.Document", "Documents")
                        .WithMany("RoleDocuments")
                        .HasForeignKey("DocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheThanh_WebAPI_Flight.Data.RolePermission", "RolePermissions")
                        .WithMany("RoleDocuments")
                        .HasForeignKey("RoleID", "PermissionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Documents");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RoleDocumentType", b =>
                {
                    b.HasOne("TheThanh_WebAPI_Flight.Data.DocumentType", "DocumentTypes")
                        .WithMany("RoleDocumentTypes")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheThanh_WebAPI_Flight.Data.RolePermission", "RolePermissions")
                        .WithMany("RoleDocumentTypes")
                        .HasForeignKey("RoleID", "PermissionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DocumentTypes");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RolePermission", b =>
                {
                    b.HasOne("TheThanh_WebAPI_Flight.Data.Permission", "Permissions")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheThanh_WebAPI_Flight.Data.Role", "Roles")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissions");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RoleUser", b =>
                {
                    b.HasOne("TheThanh_WebAPI_Flight.Data.Role", "Roles")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TheThanh_WebAPI_Flight.Data.User", "Users")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Document", b =>
                {
                    b.Navigation("RoleDocuments");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.DocumentType", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("RoleDocumentTypes");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Flight", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("RoleUsers");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.RolePermission", b =>
                {
                    b.Navigation("RoleDocumentTypes");

                    b.Navigation("RoleDocuments");
                });

            modelBuilder.Entity("TheThanh_WebAPI_Flight.Data.User", b =>
                {
                    b.Navigation("DocumentTypes");

                    b.Navigation("Documents");

                    b.Navigation("RefreshTokens");

                    b.Navigation("RoleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
