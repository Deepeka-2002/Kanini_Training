﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rel2.Models;

#nullable disable

namespace Rel2.Migrations
{
    [DbContext(typeof(CompanyContextCF))]
    [Migration("20230524162130_CreateDB")]
    partial class CreateDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Rel2.Models.Dept", b =>
                {
                    b.Property<int>("Deptno")
                        .HasColumnType("int");

                    b.Property<string>("Deptname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Deptno");

                    b.ToTable("Depts");
                });

            modelBuilder.Entity("Rel2.Models.Emp", b =>
                {
                    b.Property<int>("Empno")
                        .HasColumnType("int");

                    b.Property<int?>("Deptno")
                        .HasColumnType("int");

                    b.Property<int?>("DeptnoNavigationDeptno")
                        .HasColumnType("int");

                    b.Property<string>("EName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Empno");

                    b.HasIndex("DeptnoNavigationDeptno");

                    b.ToTable("Emps");
                });

            modelBuilder.Entity("Rel2.Models.Emp", b =>
                {
                    b.HasOne("Rel2.Models.Dept", "DeptnoNavigation")
                        .WithMany("Emps")
                        .HasForeignKey("DeptnoNavigationDeptno");

                    b.Navigation("DeptnoNavigation");
                });

            modelBuilder.Entity("Rel2.Models.Dept", b =>
                {
                    b.Navigation("Emps");
                });
#pragma warning restore 612, 618
        }
    }
}
