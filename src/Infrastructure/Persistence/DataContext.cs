using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.LogisticsDetails;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public virtual DbSet<LogisticsDetail> LogisticsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogisticsDetail>(b =>
            {
                b.ToTable("LogisticsDetails").HasKey(x => x.Id);
                b.HasOne(a => a.User).WithOne(b => b.LogisticsDetail).HasForeignKey<User>(b => b.LogisticsUserId);
                b.OwnsOne(x => x.Dimension, sb => {
                    sb.Property(x => x.CalculatedDimension).HasMaxLength(255);
                    sb.Property(x => x.Depth).HasMaxLength(255);
                    sb.Property(x => x.Width).HasMaxLength(255);
                    sb.Property(x => x.Height).HasMaxLength(255);
                });
                b.OwnsOne(x => x.WeightKg, sb => sb.Property(x => x.Weight));
            });
        }
    }
}