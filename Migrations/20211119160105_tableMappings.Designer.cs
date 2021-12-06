﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Myplace.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyPlace.Migrations
{
    [DbContext(typeof(MyPlaceDbContext))]
    [Migration("20211119160105_tableMappings")]
    partial class tableMappings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MyPlace.Negocios.Endereco", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("fornecedorId")
                        .HasColumnType("uuid");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.HasIndex("fornecedorId")
                        .IsUnique();

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("MyPlace.Negocios.Fornecedor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("tipoFornecedor")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("fornecedores");
                });

            modelBuilder.Entity("MyPlace.Negocios.Produto", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("fornecedorId")
                        .HasColumnType("uuid");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("valor")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.HasIndex("fornecedorId");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("MyPlace.Negocios.Endereco", b =>
                {
                    b.HasOne("MyPlace.Negocios.Fornecedor", "fornecedor")
                        .WithOne("endereco")
                        .HasForeignKey("MyPlace.Negocios.Endereco", "fornecedorId")
                        .IsRequired();

                    b.Navigation("fornecedor");
                });

            modelBuilder.Entity("MyPlace.Negocios.Produto", b =>
                {
                    b.HasOne("MyPlace.Negocios.Fornecedor", "fornecedor")
                        .WithMany("produtos")
                        .HasForeignKey("fornecedorId")
                        .IsRequired();

                    b.Navigation("fornecedor");
                });

            modelBuilder.Entity("MyPlace.Negocios.Fornecedor", b =>
                {
                    b.Navigation("endereco");

                    b.Navigation("produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
