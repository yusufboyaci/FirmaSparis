using FirmaSiparis.CORE.Entity;
using FirmaSiparis.ENTITIES.Entities;
using FirmaSiparis.ENTITIES.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.DATAACCESS.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FirmaMap());
            modelBuilder.ApplyConfiguration(new SiparisMap());
            modelBuilder.ApplyConfiguration(new UrunMap());
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            List<EntityEntry> modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            DateTime dateTime = DateTime.Now;
            modifiedEntries.ForEach(x =>
            {
                BaseEntity? entity = x.Entity as BaseEntity;
                if (entity != null)
                {
                    if (x.State == EntityState.Added)
                    {
                        entity.CreatedDate = dateTime;
                    }
                    else if (x.State == EntityState.Modified)
                    {
                        entity.ModifiedDate = dateTime;
                    }
                }
            });
            return base.SaveChanges();
        }
    }
}
