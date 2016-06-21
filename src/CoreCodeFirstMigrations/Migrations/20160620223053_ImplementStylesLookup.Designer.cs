using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreCodeFirstMigrations.Models;

namespace CoreCodeFirstMigrations.Migrations
{
    [DbContext(typeof(BreweryContext))]
    [Migration("20160620223053_ImplementStylesLookup")]
    partial class ImplementStylesLookup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreCodeFirstMigrations.Models.Beer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BreweryName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("StyleId");

                    b.HasKey("ID");

                    b.HasIndex("StyleId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("CoreCodeFirstMigrations.Models.Style", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ID");

                    b.ToTable("Style");
                });

            modelBuilder.Entity("CoreCodeFirstMigrations.Models.Beer", b =>
                {
                    b.HasOne("CoreCodeFirstMigrations.Models.Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
