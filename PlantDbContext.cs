using Data.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data
{
    public class PlantDbContext:DbContext
    {
        public PlantDbContext():base()
        {

        }
        public DbSet<Zones> Zones { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<ZonePlants> ZonePlants { get; set; }
        public DbSet<PlantSpecies> PlantSpecies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zones>().ToTable("zones");
            modelBuilder.Entity<Zones>()
                .Property(z => z.name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name")
                .HasColumnType("varchar");
            modelBuilder.Entity<Zones>()
                .Property(z => z.id)
                .HasColumnName("zone_id")
                .HasDefaultValue(0);
            modelBuilder.Entity<Zones>()
                .Property(z => z.type)
                .HasColumnName("type")
                .HasColumnType("varchar");
            modelBuilder.Entity<Zones>()
                .Property(z => z.area_ha)
                .HasColumnName("area_ha")
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Facilities>().ToTable("facilities");
            modelBuilder.Entity<Facilities>()
                .Property(f => f.id)
                .HasColumnName("facility_id")
                .HasDefaultValue(0);
            modelBuilder.Entity<Facilities>()
                .Property(f => f.type)
                .IsRequired()
                .HasColumnName("type")
                .HasColumnType("varchar");
            modelBuilder.Entity<Facilities>()
                .Property(f => f.material)
                .HasColumnName("material")
                .HasColumnType("varchar");
            modelBuilder.Entity<Facilities>()
                .Property(f => f.condition)
                .IsRequired()
                .HasColumnName("condition")
                .HasColumnType("varchar")
                .HasDefaultValue("good");
            modelBuilder.Entity<Facilities>()
                .Property(f => f.installed_on)
                .HasColumnName("installed_on")
                .HasColumnType("date");
            modelBuilder.Entity<Facilities>()
                .HasOne(f => f.Zone)
                .WithMany(z => z.Facilities)
                .HasForeignKey(f => f.zone_id)
                .HasConstraintName("zone_id")
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<PlantSpecies>().ToTable("plant_species");
            modelBuilder.Entity<PlantSpecies>()
                .Property(ps => ps.id)
                .HasColumnName("plant_species_id")
                .HasDefaultValue(0);
            modelBuilder.Entity<PlantSpecies>()
                .Property(ps => ps.name)
                .HasColumnType("varchar");
            modelBuilder.Entity<PlantSpecies>()
                .HasIndex(ps => ps.name)
                .IsUnique();
            modelBuilder.Entity<PlantSpecies>()
                .Property(ps => ps.latin_name)
                .HasColumnType("varchar");
            modelBuilder.Entity<PlantSpecies>()
                .HasIndex(ps => ps.latin_name)
                .IsUnique();
            modelBuilder.Entity<PlantSpecies>()
                .Property(ps => ps.is_protected)
                .HasColumnName("is_protected")
                .HasColumnType("bit");
            modelBuilder.Entity<PlantSpecies>()
                .Property(ps => ps.description)
                .HasColumnName("description")
                .HasColumnType("varchar");

            modelBuilder.Entity<ZonePlants>().ToTable("zone_plants");
            modelBuilder.Entity<ZonePlants>()
                .HasKey(zp => new { zp.zone_id, zp.plant_id });
            modelBuilder.Entity<ZonePlants>()
                .HasOne(zp => zp.Zone)
                .WithMany(z => z.ZonePlants)
                .HasForeignKey(zp => zp.zone_id);
            modelBuilder.Entity<ZonePlants>()
                .HasOne(zp => zp.PlantSpecies)
                .WithMany(z => z.ZonePlants)
                .HasForeignKey(zp => zp.plant_id);
            modelBuilder.Entity<ZonePlants>()
                .Property(zp =>zp.density)
                .HasConversion<string>()  
                .HasColumnType("varchar");

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=STUDENT15;Initial Catalog=CarService-Update; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

    }
}
