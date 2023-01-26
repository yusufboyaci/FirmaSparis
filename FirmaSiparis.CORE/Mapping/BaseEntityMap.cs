using FirmaSiparis.CORE.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.CORE.Mapping
{
    public class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Status).IsRequired(true);
            builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Zamanı").IsRequired(true);
            builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Zamanı").IsRequired(true);
        }
    }
}
