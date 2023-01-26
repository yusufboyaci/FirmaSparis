using FirmaSiparis.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.ENTITIES.Entities
{
    public class Siparis : BaseEntity
    {
        public Guid FirmaId { get; set; }//FK
        public Guid UrunId { get; set; }//FK
        public string SiparisiVereninAdi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public virtual Urun? Urun { get; set; }
        public virtual Firma? Firma { get; set; }
    }
}
