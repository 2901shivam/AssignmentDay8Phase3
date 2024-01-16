using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssignmentDay8.Models
{
    public partial class bookdbContext : DbContext
    {
        public bookdbContext()
        {
        }

        public bookdbContext(DbContextOptions<bookdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookAuthor> BookAuthors { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Writer> Writers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:shivamadmin.database.windows.net,1433;Initial Catalog=bookdb;Persist Security Info=False;User ID=shivam;Password=Singh2901@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Wid)
                    .HasName("PK__Author__DB3765391BFC5638");

                entity.ToTable("Author");

                entity.Property(e => e.Wid)
                    .ValueGeneratedNever()
                    .HasColumnName("WId");

                entity.Property(e => e.Wname)
                    .HasMaxLength(50)
                    .HasColumnName("WName");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.BookName).HasMaxLength(50);

                entity.Property(e => e.Bookcategory).HasMaxLength(50);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BookAuthor");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Publisher");

                entity.Property(e => e.PublisherAddress).HasMaxLength(50);

                entity.Property(e => e.PublisherName).HasMaxLength(50);
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.HasKey(e => e.Wid)
                    .HasName("PK__Writer__DB37653986AD49BB");

                entity.ToTable("Writer");

                entity.Property(e => e.Wid)
                    .ValueGeneratedNever()
                    .HasColumnName("WId");

                entity.Property(e => e.Wname)
                    .HasMaxLength(50)
                    .HasColumnName("WName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
