using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShowPets.Models
{
    public partial class ShowPetsContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ShowPetsContext()
        {
        }

        public ShowPetsContext(DbContextOptions<ShowPetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=ctrlaltpc200414666.database.windows.net;Initial Catalog=ShowPets;Persist Security Info=True;User ID=li;Password=@Ejiu04xu3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasOne(d => d.Species)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pet_Species");
            });
        }
    }
}
