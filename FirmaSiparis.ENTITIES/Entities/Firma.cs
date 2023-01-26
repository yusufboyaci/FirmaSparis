using FirmaSiparis.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparis.ENTITIES.Entities
{
    public class Firma : BaseEntity
    {
        public string? FirmaAdi { get; set; }
        public bool OnayDurumu { get; set; }
        public TimeSpan SiparisIzinBasSaati { get; set; }
        public TimeSpan SiparisIzinBitisSaati { get; set; }
        public virtual List<Urun>? Urunler { get; set; }
        public virtual List<Siparis>? Siparisler { get; set; }
    }
}
