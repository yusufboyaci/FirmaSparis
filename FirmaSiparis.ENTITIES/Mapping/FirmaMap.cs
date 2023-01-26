using FirmaSiparis.CORE.Entity;
using FirmaSiparis.CORE.Mapping;
using FirmaSiparis.ENTITIES.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.ENTITIES.Mapping
{
    public class FirmaMap : BaseEntityMap<Firma>
    {
        public override void Configure(EntityTypeBuilder<Firma> builder)
        {
            builder.Property(x => x.FirmaAdi).HasMaxLength(100).IsRequired(true);
            base.Configure(builder);
        }
    }
}
