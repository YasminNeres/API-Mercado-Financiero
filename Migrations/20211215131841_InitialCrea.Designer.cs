﻿// <auto-generated />
using MercadoFinanciero.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MercadoFinanciero.Migrations
{
    [DbContext(typeof(MercadoContext))]
    [Migration("20211215131841_InitialCrea")]
    partial class InitialCrea
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MercadoFinanciero.Models.MercadoF", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Max")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Ultimo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Nombre");

                    b.ToTable("MercadoFs");
                });
#pragma warning restore 612, 618
        }
    }
}
