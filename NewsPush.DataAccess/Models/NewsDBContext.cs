using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewsPush.DataAccess.Models
{
    public partial class NewsDBContext : DbContext
    {
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersCategories> UsersCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=YIBSONLEUDO\SQLEXPRESS;Initial Catalog=NewsDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("Categories", "Business");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.IdNews);

                entity.ToTable("News", "Business");

                entity.Property(e => e.IdNews).HasColumnName("idNews");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__News__idCategory__3D5E1FD2");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("Users", "Security");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("deviceId")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersCategories>(entity =>
            {
                entity.HasKey(e => e.IdUsersCategories);

                entity.ToTable("UsersCategories", "Business");

                entity.Property(e => e.IdUsersCategories).HasColumnName("idUsersCategories");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.UsersCategories)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__UsersCate__idCat__4316F928");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UsersCategories)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__UsersCate__idUse__4222D4EF");
            });
        }
    }
}
