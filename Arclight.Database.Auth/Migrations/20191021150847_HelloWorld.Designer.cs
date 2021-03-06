﻿// <auto-generated />
using System;
using Arclight.Database.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Arclight.Database.Auth.Migrations
{
    [DbContext(typeof(AuthContext))]
    [Migration("20191021150847_HelloWorld")]
    partial class HelloWorld
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Arclight.Database.Auth.Model.AccountCharacterCountModel", b =>
                {
                    b.Property<uint>("Id")
                        .HasColumnType("int unsigned");

                    b.Property<byte>("Count")
                        .HasColumnType("tinyint unsigned");

                    b.Property<uint>("ServerId")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("account_character_count");
                });

            modelBuilder.Entity("Arclight.Database.Auth.Model.AccountModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<ulong?>("SessionKey")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("Id", "SessionKey");

                    b.ToTable("account");
                });

            modelBuilder.Entity("Arclight.Database.Auth.Model.ServerClusterModel", b =>
                {
                    b.Property<uint>("Id")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("Index")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasMaxLength(64);

                    b.Property<ushort>("Port")
                        .HasColumnType("smallint unsigned");

                    b.HasKey("Id", "Index");

                    b.ToTable("server_cluster");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            Index = 1u,
                            Host = "127.0.0.1",
                            Port = (ushort)10200
                        });
                });

            modelBuilder.Entity("Arclight.Database.Auth.Model.ServerModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasMaxLength(32);

                    b.Property<ushort>("Port")
                        .HasColumnType("smallint unsigned");

                    b.HasKey("Id");

                    b.ToTable("server");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            Host = "127.0.0.1",
                            Name = "Arclight Server",
                            Port = (ushort)10100
                        });
                });

            modelBuilder.Entity("Arclight.Database.Auth.Model.AccountCharacterCountModel", b =>
                {
                    b.HasOne("Arclight.Database.Auth.Model.AccountModel", "Account")
                        .WithMany("CharacterCounts")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arclight.Database.Auth.Model.ServerModel", "Server")
                        .WithMany("CharacterCounts")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Arclight.Database.Auth.Model.ServerClusterModel", b =>
                {
                    b.HasOne("Arclight.Database.Auth.Model.ServerModel", "Server")
                        .WithMany("Nodes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
