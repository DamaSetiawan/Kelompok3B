using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UTS.Models
{
    public partial class BillyardContext : DbContext
    {
        public BillyardContext()
        {
        }

        public BillyardContext(DbContextOptions<BillyardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Packet> Packet { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdAccount);

                entity.Property(e => e.IdAccount).HasColumnName("ID_Account");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdType).HasColumnName("ID_Type");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.CodePayment)
                    .HasColumnName("Code_Payment")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ExpireDate)
                    .HasColumnName("Expire_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPacket).HasColumnName("ID_Packet");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("Order_Date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdPacketNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdPacket)
                    .HasConstraintName("FK_Order_Packet");

                entity.HasOne(d => d.IdPacket1)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdPacket)
                    .HasConstraintName("FK_Order_Table");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_Order_Order_Status");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("Order_Status");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.Property(e => e.StatusName)
                    .HasColumnName("Status_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Packet>(entity =>
            {
                entity.HasKey(e => e.IdPacket);

                entity.Property(e => e.IdPacket).HasColumnName("ID_Packet");

                entity.Property(e => e.PacketName)
                    .HasColumnName("Packet_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PacketTime)
                    .HasColumnName("Packet_Time")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => e.IdTable);

                entity.Property(e => e.IdTable).HasColumnName("ID_Table");

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Table)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_Table_Order");
            });
        }
    }
}
