using FirmaSiparis.CORE.Mapping;
using FirmaSiparis.ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.ENTITIES.Mapping
{
    public class UrunMap : BaseEntityMap<Urun>
    {
        public override void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.Property(x => x.UrunAdi).HasMaxLength(250).IsRequired(true);
            builder.Property(x => x.Stok).IsRequired(true);
            builder.Property(x => x.Fiyat).HasColumnType("decimal(10,2)").IsRequired(true);
            builder.HasOne(x => x.Firma).WithMany(x => x.Urunler).HasForeignKey(x => x.FirmaId).OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
