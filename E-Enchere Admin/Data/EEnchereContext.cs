using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace E_Enchere_Admin.Models
{
    public partial class EEnchereContext : DbContext
    {
        public EEnchereContext()
        {
        }

        public EEnchereContext(DbContextOptions<EEnchereContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientRoom> ClientRooms { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RIM;Database=E-Enchere;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdArticle);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);
            });

            modelBuilder.Entity<ClientRoom>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.IdRoom });

                entity.ToTable("Client_Rooms");

                entity.HasIndex(e => e.IdRoom, "IX_Client_Rooms_IdRoom");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.ClientRooms)
                    .HasForeignKey(d => d.IdClient);

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.ClientRooms)
                    .HasForeignKey(d => d.IdRoom);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom);

                entity.HasIndex(e => e.IdArticle, "IX_Rooms_IdArticle");

                entity.HasOne(d => d.IdArticleNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.IdArticle);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
