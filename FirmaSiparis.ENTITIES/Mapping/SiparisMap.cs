using FirmaSiparis.CORE.Entity;
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
    public class SiparisMap : BaseEntityMap<Siparis>
    {
        public override void Configure(EntityTypeBuilder<Siparis> builder)
        {
            builder.Property(x => x.SiparisiVereninAdi).HasMaxLength(100).IsRequired(true);
            builder.HasOne(x => x.Firma).WithMany(x => x.Siparisler).HasForeignKey(x => x.FirmaId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Urun).WithMany(x => x.Siparisler).HasForeignKey(x =>x.UrunId).OnDelete(DeleteBehavior.NoAction); 
            base.Configure(builder);
        }
    }
}
