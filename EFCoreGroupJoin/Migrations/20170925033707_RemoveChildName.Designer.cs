﻿// <auto-generated />
using EFCoreGroupJoin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EFCoreGroupJoin.Migrations
{
    [DbContext(typeof(GroupJoinContext))]
    [Migration("20170925033707_RemoveChildName")]
    partial class RemoveChildName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreGroupJoin.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OtherParentId");

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("OtherParentId");

                    b.HasIndex("ParentId");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("EFCoreGroupJoin.OtherParent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("OtherParent");
                });

            modelBuilder.Entity("EFCoreGroupJoin.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Parent");
                });

            modelBuilder.Entity("EFCoreGroupJoin.Child", b =>
                {
                    b.HasOne("EFCoreGroupJoin.OtherParent", "OtherParent")
                        .WithMany()
                        .HasForeignKey("OtherParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreGroupJoin.Parent", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
