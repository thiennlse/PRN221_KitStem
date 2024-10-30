using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class KitStemDBContext : DbContext
    {
        public KitStemDBContext()
        {
        }

        public KitStemDBContext(DbContextOptions<KitStemDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                IConfiguration config = configBuilder.Build();
                string connectionString = config.GetConnectionString("local");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<HelpHistory> HelpHistories { get; set; } = null!;
        public virtual DbSet<KitOrder> KitOrders { get; set; } = null!;
        public virtual DbSet<KitStem> KitStems { get; set; } = null!;
        public virtual DbSet<Lab> Labs { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Step> Steps { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserLab> UserLabs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("Cart_Items");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.KitId).HasColumnName("kit_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Kit)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.KitId)
                    .HasConstraintName("FK__Cart_Item__kit_i__36B12243");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Cart_Item__user___35BCFE0A");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.KitId).HasColumnName("kit_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Kit)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.KitId)
                    .HasConstraintName("FK__Favorites__kit_i__412EB0B6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Favorites__user___403A8C7D");
            });

            modelBuilder.Entity<HelpHistory>(entity =>
            {
                entity.ToTable("Help_Histories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StepId).HasColumnName("step_id");

                entity.Property(e => e.UserLabId).HasColumnName("user_lab_id");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.HelpHistories)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.NoAction)  // Prevent cascading delete
                    .HasConstraintName("FK__Help_Hist__step___32E0915F");

                entity.HasOne(d => d.UserLab)
                    .WithMany(p => p.HelpHistories)
                    .HasForeignKey(d => d.UserLabId)
                    .OnDelete(DeleteBehavior.NoAction)  // Prevent cascading delete here too
                    .HasConstraintName("FK__Help_Hist__user___31EC6D26");
            });

            modelBuilder.Entity<KitOrder>(entity =>
            {
                entity.ToTable("Kit_Orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.KitId).HasColumnName("kit_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Kit)
                    .WithMany(p => p.KitOrders)
                    .HasForeignKey(d => d.KitId)
                    .HasConstraintName("FK__Kit_Order__kit_i__3D5E1FD2");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.KitOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Kit_Order__order__3C69FB99");
            });

            modelBuilder.Entity<KitStem>(entity =>
            {
                entity.ToTable("Kit_Stems");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("attribute");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Lab>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("description");

                entity.Property(e => e.KitId).HasColumnName("kit_id");

                entity.HasOne(d => d.Kit)
                    .WithMany(p => p.Labs)
                    .HasForeignKey(d => d.KitId)
                    .HasConstraintName("FK__Labs__kit_id__286302EC");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.CreateDay)
                    .HasColumnType("datetime")
                    .HasColumnName("create_day");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.OrderDay)
                    .HasColumnType("datetime")
                    .HasColumnName("order_day");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__user_id__398D8EEE");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.LabId).HasColumnName("lab_id");

                entity.HasOne(d => d.Lab)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.LabId)
                    .HasConstraintName("FK__Steps__lab_id__2B3F6F97");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("description");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserLab>(entity =>
            {
                entity.ToTable("User_Labs");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.LabId).HasColumnName("lab_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Lab)
                    .WithMany(p => p.UserLabs)
                    .HasForeignKey(d => d.LabId)
                    .HasConstraintName("FK__User_Labs__lab_i__2F10007B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLabs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__User_Labs__user___2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
