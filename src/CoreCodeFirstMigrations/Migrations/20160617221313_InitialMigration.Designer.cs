using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreCodeFirstMigrations.Models;

namespace CoreCodeFirstMigrations.Migrations
{
    [DbContext(typeof(BreweryContext))]
    [Migration("20160617221313_InitialMigration")]
    partial class InitialMigration
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

                    b.Property<string>("BreweryName");

                    b.Property<string>("Name");

                    b.Property<string>("Style");

                    b.HasKey("ID");

                    b.ToTable("Beers");
                });
        }
    }
}
