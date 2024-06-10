using App.Application.Abstractions;
using App.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infrastructure.Persistance
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<RolesOfUsers> RolesOfUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureComments(modelBuilder);
            ConfigureReplies(modelBuilder);
            ConfigureBooks(modelBuilder);
            ConfigureUserModels(modelBuilder);
            ConfigureUserRoles(modelBuilder);
            ConfigureIndices(modelBuilder);
            ConfigureTags(modelBuilder);
            ConfigureCategories(modelBuilder);
        }

        private void ConfigureComments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CommentText)
                      .IsRequired()
                      .HasMaxLength(2000);

                entity.Property(e => e.CreatedDate)
                      .HasDefaultValueSql("getutcdate()");

                entity.HasOne(e => e.Book)
                      .WithMany(b => b.Comments)
                      .HasForeignKey(e => e.BookId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureReplies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedDate)
                      .HasDefaultValueSql("getutcdate()");

                entity.HasOne(r => r.OriginalComment)
                      .WithMany()
                      .HasForeignKey(r => r.OriginalCommentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.ReplyComment)
                      .WithMany()
                      .HasForeignKey(r => r.ReplyCommentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                // Другие настройки для Book
            });
        }

        private void ConfigureUserModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(255);
                // Другие настройки для UserModel
            });
        }

        private void ConfigureUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }

        private void ConfigureIndices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(b => b.Title);
        }

        private void ConfigureTags(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });
        }

        private void ConfigureCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
}
