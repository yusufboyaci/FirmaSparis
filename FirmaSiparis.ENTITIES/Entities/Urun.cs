using FirmaSiparis.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.ENTITIES.Entities
{
    public class Urun : BaseEntity
    {
        public Guid FirmaId { get; set; }//FK
        public string UrunAdi { get; set; }
        public int Stok { get; set; } = 0;
        public decimal Fiyat { get; set; } = 0.00m;
        public virtual Firma? Firma { get; set; }
        public virtual List<Siparis>? Siparisler { get; set; }
    }
}
